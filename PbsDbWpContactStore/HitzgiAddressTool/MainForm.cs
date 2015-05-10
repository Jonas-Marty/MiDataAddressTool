using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using log4net;
using MoreLinq;
using Newtonsoft.Json;
using PbsDbAccess;
using PbsDbAccess.Models;

namespace HitzgiAddressTool
{
	public partial class MainForm : Form
	{
		private readonly ILog _log = LogManager.GetLogger(typeof(MainForm));

		public InformationExchanger InformationExchanger { get; set; }

		private PbsDbWebAccess PbsDbWebAccess
		{
			get { return InformationExchanger.PbsDbWebAccess; }
		}

		private readonly Dictionary<Group, IEnumerable<Person>> _groupPeopleAssociations =
			new Dictionary<Group, IEnumerable<Person>>();

		private List<Group> _groups = new List<Group>();

		private HitzgiAmountCalculator _hitzgiAmountCalculator;
		private bool _groupAndPeopleLoadingComplete;
		private Task _prioritySaveTask;

		public MainForm()
		{
			InitializeComponent();
		}

		private async void MainForm_Shown(object sender, EventArgs e)
		{
			statusLabel.Text = "Lade Gruppen...";

			_groups = (await PbsDbWebAccess.RecieveAllGroupsFromLayerGroupRecursiveAsync()).ToList();
			_log.Info(string.Format("Successfully loaded all Groups ({0})", string.Join(",", _groups.Select(group => group.Name))));
			await Task.Run(() => SetGroupPriorities());

			SetDataSourceToGroupCheckedListBox();

			loadingGroupsPictureBox.Visible = false;
			statusLabel.Text = "Bitte wähle nun alle Gruppen aus, dessen Mitglieder ein Hitzgi erhalten sollen";

			groupsCheckedListBox.Enabled = true;
			bottomStatusLabel.Visible = true;
			bottomLoadingPictureBox.Visible = true;


			foreach (Group group in _groups)
			{
				bottomStatusLabel.Text = "Lade Personen aus " + group.Name;
				IEnumerable<Person> people = await PbsDbWebAccess.RecievePersonsOfGroupAsync(group.Id);
				_log.Info(string.Format("People from group {0} successfully downloaded", @group.Name));
				_groupPeopleAssociations.Add(group, people);
			}

			bottomLoadingPictureBox.Visible = false;
			bottomStatusLabel.Text = "Download aller Personen abgeschlossen";
			_log.Info("Download of all People was successful");
			_hitzgiAmountCalculator = new HitzgiAmountCalculator(_groupPeopleAssociations);
			await Task.Delay(1000);
			bottomStatusLabel.Visible = false;
			_groupAndPeopleLoadingComplete = true;
			groupsCheckedListBox.Visible = true;
			excelButton.Visible = true;
			priorityUpButton.Visible = true;
			priorityDownButton.Visible = true;
			priorityInfoLabel.Visible = true;

			//make sure the counts get evaluated if the user have already selected some groups
			groupsCheckedListBox_SelectedIndexChanged(null, null);
		}

		private void SetGroupPriorities()
		{
			Dictionary<string, int> groupPriorities;
			if (TryLoadPriorityList(out groupPriorities))
			{
				ApplyGroupPriorities(groupPriorities);
			} //else ignore
		}

		private void ApplyGroupPriorities(Dictionary<string, int> groupPriorities)
		{
			var priorityOrderedGroups = _groups.OrderByDescending(group =>
			{
				int priority;
				if (!groupPriorities.TryGetValue(group.Id, out priority))
				{
					priority = 0;
				}
				return priority;
			});

			_groups = priorityOrderedGroups.ToList();
		}

		private void groupsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_groupAndPeopleLoadingComplete) //do calculation only if download complete
			{
				return;
			}

			var selectedGroups = GetCheckedGroups();

			bool enableNextStep = selectedGroups.Count > 0;

			excelButton.Enabled = enableNextStep;
			priorityDownButton.Enabled = enableNextStep;
			priorityUpButton.Enabled = enableNextStep;

			int hitzgiAmount = _hitzgiAmountCalculator.CalculateTotalAmountOfHitzgisNeeded(selectedGroups);
			int distinctHitzgiRecievers = _hitzgiAmountCalculator.CalculateTotalAmountOfDistinctHitzgiRecievers(selectedGroups);

			bottomStatusLabel.Visible = true;
			bottomStatusLabel.Text = string.Format("Um die {0} Personen zu adressieren würden {1} Hitzgis benötigt.", distinctHitzgiRecievers, hitzgiAmount);
		}

		private List<Group> GetCheckedGroups()
		{
			return groupsCheckedListBox.CheckedItems.Cast<Group>().ToList();
		}

		private void excelButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog fileDialog = new SaveFileDialog
			{
				AddExtension = true,
				CheckPathExists = true,
				DefaultExt = ".xlsx",
				OverwritePrompt = true,
				Title = "Adressliste speichern",
				Filter = "Excel Datei (*.xlsx)|*.xlsx"
			};

			DialogResult result = fileDialog.ShowDialog();
			if (result != DialogResult.OK)
			{
				return;
			}

			try
			{
				GenerateAndSaveExcelFile(fileDialog.FileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					string.Format(
						"Excel file konnte nicht gespeichert werden. Wende dich an den ersteller des Programs.\nError: \"{0}\"",
						ex.Message));
				_log.Error("Excel file could not be saved", ex);
			}
		}

		private void GenerateAndSaveExcelFile(string fileName)
		{
			var selectedGroups = GetCheckedGroups();
			var distinctPeople = _hitzgiAmountCalculator.GetPersonsDistinct(selectedGroups).ToArray();
			var groupPriorities = GetUserSetGroupPriority();

			Dictionary<Person, Group> prioritizedPeopleGroupAssociation =
				AssociateGroupsToPeopleAccordingToThePriorityList(distinctPeople, selectedGroups, groupPriorities);

			var orderedPeople = prioritizedPeopleGroupAssociation
				.OrderBy(kvp => kvp.Key.Address)
				.ThenBy(kvp => kvp.Value.Id);

			var rows = orderedPeople.Select(kvp => new
			{
				Vorname = kvp.Key.FirstName,
				Name = kvp.Key.LastName,
				Pfadiname = kvp.Key.Nickname,
				Strasse = kvp.Key.Address,
				PLZ = kvp.Key.ZipCode,
				Ort = kvp.Key.Town,
				Einheit = kvp.Value.Name
			}).ToArray();


			var excelDocument = ExcelDocument.CreateWithSimpleHeader(rows, true, "Adressen");
			excelDocument.CloseDocumentAndSaveToFile(new FileInfo(fileName));
			_log.Info(string.Format("Excel file successfully created at \"{0}\"", fileName));
			Process.Start(fileName);
		}

		private Dictionary<string, int> GetUserSetGroupPriority()
		{
			return groupsCheckedListBox.Items.Cast<Group>()
				.ToDictionary(
					group => group.Id,
					group => _groups.Count - _groups.IndexOf(group) //Indexes of _groups are in sync with the ones in groupsCheckedListBox
				);
		}

		private Dictionary<Person, Group> AssociateGroupsToPeopleAccordingToThePriorityList(Person[] distinctPeople, List<Group> selectedGroups, Dictionary<string, int> groupPriorities)
		{
			groupPriorities =
				groupPriorities.Where(groupPriority => selectedGroups.Any(selectedGroup => selectedGroup.Id == groupPriority.Key))
					.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

			return distinctPeople.ToDictionary(person => person,
				person => _groupPeopleAssociations
					.Where(kvp => kvp.Value.Any(personInGroup => personInGroup.Id == person.Id))
					.Select(kvp => kvp.Key)
					.MaxBy(groupWherePersonIsIn =>
					{
						int prioritiy;
						if (!groupPriorities.TryGetValue(groupWherePersonIsIn.Id, out prioritiy))
						{
							prioritiy = -1; //groupPriorities only contains select groups, if group is not selected set priority to a low value
						}
						return prioritiy;
					}));
		}

		private void priorityUpButton_Click(object sender, EventArgs e)
		{
			if (!IsAnyElementSelected(groupsCheckedListBox))
			{
				return;
			}

			MoveGroupRelativeToItsPosition(-1);
			SaveCurrentPriorityList();
		}

		private void priorityDownButton_Click(object sender, EventArgs e)
		{
			if (!IsAnyElementSelected(groupsCheckedListBox))
			{
				return;
			}

			MoveGroupRelativeToItsPosition(1);
			SaveCurrentPriorityList();
		}

		private void MoveGroupRelativeToItsPosition(int positionsToMove)
		{
			int selectedIndex = groupsCheckedListBox.SelectedIndex;
			int newIndex = selectedIndex + positionsToMove;

			if (newIndex < 0 || newIndex >= _groups.Count)
			{
				return;
			}

			List<Group> checkedGroups = GetCheckedGroups();

			MoveItemAndSelectedIndex(newIndex, selectedIndex);

			SetDataSourceToGroupCheckedListBox();

			RestoreSelectedGroups(checkedGroups);
		}

		private void MoveItemAndSelectedIndex(int newIndex, int selectedIndex)
		{

			Group groupToMove = _groups[selectedIndex];
			_groups.RemoveRange(selectedIndex, 1);
			_groups.Insert(newIndex, groupToMove);

			groupsCheckedListBox.SelectedIndex = newIndex;
		}

		private void RestoreSelectedGroups(List<Group> groupsToSelect)
		{
			foreach (var group in groupsToSelect)
			{
				groupsCheckedListBox.SetItemChecked(_groups.IndexOf(group), true);
			}

			//reset selected index specific things
			groupsCheckedListBox_SelectedIndexChanged(null, null);
		}

		private void SetDataSourceToGroupCheckedListBox()
		{
			groupsCheckedListBox.DataSource = null;
			groupsCheckedListBox.DataSource = _groups;
			groupsCheckedListBox.DisplayMember = "Name";
		}

		private static bool IsAnyElementSelected(CheckedListBox checkedListBox)
		{
			return checkedListBox.SelectedIndex != -1;
		}

		private void SaveCurrentPriorityList()
		{
			Dictionary<string, int> groupPriorities = GetUserSetGroupPriority();

			_prioritySaveTask = Task.Run(() => FileUtil.SaveGroupPriorities(groupPriorities));
			_prioritySaveTask.ContinueWith(HandelGroupPrioritySaveTaskExceptions);
		}

		private void HandelGroupPrioritySaveTaskExceptions(Task finishedTask)
		{
			if (finishedTask.IsFaulted)
			{
				_log.Warn("Save of group priority list failed", finishedTask.Exception);
			}
			else
			{
				_log.Info("Save of group priority list was successfull");
			}
		}

		private bool TryLoadPriorityList(out Dictionary<string, int> groupPriorityList)
		{
			groupPriorityList = null;
			try
			{
				groupPriorityList = FileUtil.LoadGroupPriorities();
				_log.Info("Grouppriorities successfully loaded from file");
				return true;
			}
			catch (JsonReaderException ex)
			{
				_log.Warn("Grouppriorities could not be loaded", ex);
				//somthings wrong with the json file, ignore it
			}
			catch (IOException ex)
			{
				_log.Warn("Grouppriorities could not be loaded", ex);
				//somthings wrong with the file, ignore it
			}
			return false;
		}
	}
}
