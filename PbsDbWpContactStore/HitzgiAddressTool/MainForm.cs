using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoreLinq;
using PbsDbAccess;
using PbsDbAccess.Models;

namespace HitzgiAddressTool
{
	public partial class MainForm : Form
	{
		public InformationExchanger InformationExchanger { get; set; }

		private PbsDbWebAccess PbsDbWebAccess
		{
			get { return InformationExchanger.PbsDbWebAccess; }
		}

		private Dictionary<Group, IEnumerable<Person>> _groupPeopleAssociations =
			new Dictionary<Group, IEnumerable<Person>>();

		private List<Group> _groups = new List<Group>();

		private HitzgiAmountCalculator _hitzgiAmountCalculator;
		private bool _groupAndPeopleLoadingComplete;

		public MainForm()
		{
			InitializeComponent();
			bottomStatusLabel.Visible = false;
			bottomLoadingPictureBox.Visible = false;
		}

		private async void MainForm_Shown(object sender, EventArgs e)
		{
			statusLabel.Text = "Lade Gruppen...";

			_groups = (await PbsDbWebAccess.RecieveAllGroupsFromLayerGroupRecursiveAsync()).ToList();
			groupsCheckedListBox.DataSource = _groups;
			groupsCheckedListBox.DisplayMember = "Name";

			loadingGroupsPictureBox.Visible = false;
			statusLabel.Text = "Bitte wähle nun alle Gruppen aus, dessen Mitglieder ein Hitzgi erhalten sollen";

			bottomStatusLabel.Visible = true;
			bottomLoadingPictureBox.Visible = true;

			foreach (Group group in _groups)
			{
				bottomStatusLabel.Text = "Lade Personen aus " + group.Name;
				IEnumerable<Person> people = await PbsDbWebAccess.RecievePersonsOfGroupAsync(group.Id);
				_groupPeopleAssociations.Add(group, people);
			}
			bottomLoadingPictureBox.Visible = false;
			bottomStatusLabel.Text = "Download aller Personen abgeschlossen";
			_hitzgiAmountCalculator = new HitzgiAmountCalculator(_groupPeopleAssociations);
			await Task.Delay(1000);
			bottomStatusLabel.Visible = false;
			_groupAndPeopleLoadingComplete = true;
			groupsCheckedListBox.Visible = true;
			excelButton.Visible = true;

			//make sure the counts get evaluated if the user have already selected some groups
			groupsCheckedListBox_SelectedIndexChanged(null, null);
		}

		private void groupsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_groupAndPeopleLoadingComplete) //do calculation only if download complete
			{
				return;
			}

			var selectedGroups = GetSelectedGroups();

			excelButton.Enabled = selectedGroups.Count > 0;

			int distinctHitzgiRecievers = _hitzgiAmountCalculator.CalculateTotalAmountOfDistinctHitzgiRecievers(selectedGroups);
			int hitzgiAmount = _hitzgiAmountCalculator.CalculateTotalAmountOfHitzgisNeeded(selectedGroups);

			bottomStatusLabel.Visible = true;
			bottomStatusLabel.Text = string.Format("Für die aktuelle Auswahl würden {0} Hitzgis von {1} Personen gelesen werden.", hitzgiAmount, distinctHitzgiRecievers);
		}

		private List<Group> GetSelectedGroups()
		{
			return groupsCheckedListBox.CheckedItems.Cast<Group>().ToList();
		}

		private void excelButton_Click(object sender, EventArgs e)
		{
			var selectedGroups = GetSelectedGroups();
			var distinctPeople = _hitzgiAmountCalculator.GetPersonsDistinct(selectedGroups).ToArray();

			Dictionary<Group, int> groupPriority = _groups
				.Select((group, index) => new {group, index})
				.ToDictionary(groupIndex => groupIndex.group, groupIndex => groupIndex.index);

			Dictionary<Person, Group> prioritizedPeopleGroupAssociation =
				AssociateGroupsToPeopleAccordingToThePriorityList(distinctPeople, groupPriority);

			var orderedPeople = prioritizedPeopleGroupAssociation
				.OrderBy(kvp => kvp.Key.Address)
				.ThenBy(kvp => kvp.Value.Id);
			
			FileInfo f = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "adressen.xlsx"));

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
			excelDocument.CloseDocumentAndSaveToFile(f);
			Process.Start(f.FullName);
		}

		private Dictionary<Person, Group> AssociateGroupsToPeopleAccordingToThePriorityList(Person[] distinctPeople, Dictionary<Group, int> groupPriority)
		{
			return distinctPeople.ToDictionary(person => person,
				person => _groupPeopleAssociations
					.Where(kvp => kvp.Value.Any(personInGroup => personInGroup.Id == person.Id))
					.Select(kvp => kvp.Key)
					.MaxBy(groupWherePersonIsIn => groupPriority
						.First(priorizedGroup => priorizedGroup.Key.Id == groupWherePersonIsIn.Id).Value));
		}
	}
}
