using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using MiDataAccess.Models;
using Newtonsoft.Json;

namespace MiDataAddressTool;

public partial class MainForm : Form
{
    private readonly ILog _log = LogManager.GetLogger(typeof(MainForm));

    public InformationExchanger InformationExchanger { get; set; }

    private MiDataAccess.MiDataAccess MiDataAccess => InformationExchanger.MiDataAccess;

    private readonly ConcurrentDictionary<Group, IEnumerable<Person>> _groupPeopleAssociations = new();

    private List<Group> _groups = new();

    private HitzgiAmountCalculator _hitzgiAmountCalculator;
    private bool _groupAndPeopleLoadingComplete;
    private Task _prioritySaveTask;
    private Dictionary<string, Tuple<int, bool>> _groupPriorities;

    public MainForm()
    {
        InitializeComponent();
    }

    private async void MainForm_Shown(object sender, EventArgs e)
    {
        statusLabel.Text = "Lade Gruppen...";

        _groups = (await MiDataAccess.ReceiveAllGroupsFromLayerGroupRecursiveAsync()).ToList();
        _log.Info($"Successfully loaded all Groups ({string.Join(",", _groups.Select(group => @group.Name))})");
        await Task.Run(SetGroupPriorities);

        SetDataSourceToGroupCheckedListBox();

        SetSelectedGroups();

        loadingGroupsPictureBox.Visible = false;
        statusLabel.Text = "Bitte wähle nun alle Gruppen aus, dessen Mitglieder ein Hitzgi erhalten sollen";

        groupsCheckedListBox.Enabled = true;
        bottomStatusLabel.Visible = true;
        bottomLoadingPictureBox.Visible = true;
        await Parallel.ForEachAsync(_groups.ToArray(), async (group, _) =>
        {
            IEnumerable<Person> people = await MiDataAccess.ReceivePersonsOfGroupAsync(group.Id);
            _log.Info($"People from group {group.Name} successfully downloaded");
            _groupPeopleAssociations.TryAdd(group, people);
            //System.Windows.Threading.Dispatcher.
            bottomStatusLabel.BeginInvoke(() => bottomStatusLabel.Text = "Personen aus " + group.Name + " herunter geladen");
        });

        bottomLoadingPictureBox.Visible = false;
        bottomStatusLabel.Text = "Download aller Personen abgeschlossen";
        _log.Info("Download of all People was successful");
        _hitzgiAmountCalculator = new HitzgiAmountCalculator(_groupPeopleAssociations.AsReadOnly());
        await Task.Delay(1000);
        bottomStatusLabel.Visible = false;
        _groupAndPeopleLoadingComplete = true;
        groupsCheckedListBox.Visible = true;
        excelButton.Visible = true;
        priorityUpButton.Visible = true;
        priorityDownButton.Visible = true;
        priorityInfoLabel.Visible = true;
        copyTnMobileButton.Visible = true;

        //make sure the counts get evaluated if the user have already selected some groups
        GroupsCheckedListBox_SelectedIndexChanged(null, null);
    }

    private void SetSelectedGroups()
    {
        if (_groupPriorities is null)
        {
            return;
        }

        foreach (var selectedGroup in _groupPriorities.Where(groupPriority => groupPriority.Value.Item2))
        {
            groupsCheckedListBox.SetItemChecked(_groups.FindIndex(group => group.Id == selectedGroup.Key), true);
        }
    }

    private void SetGroupPriorities()
    {
        if (TryLoadPriorityList(out var groupPriorities))
        {
            _groupPriorities = groupPriorities;
            ApplyGroupPriorities(groupPriorities);
        } //else ignore
    }

    private void ApplyGroupPriorities(Dictionary<string, Tuple<int, bool>> groupPriorities)
    {
        var priorityOrderedGroups = _groups
            .OrderByDescending(group => groupPriorities.TryGetValue(group.Id, out var groupNumberPriorityTuple) ? groupNumberPriorityTuple.Item1 : 0);
        _groups = priorityOrderedGroups.ToList();

    }

    private void GroupsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
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
        copyTnMobileButton.Enabled = enableNextStep;

        int hitzgiAmount = _hitzgiAmountCalculator.CalculateTotalAmountOfHitzgisNeeded(selectedGroups);
        int distinctHitzgiReceivers = _hitzgiAmountCalculator.CalculateTotalAmountOfDistinctHitzgiReceivers(selectedGroups);

        bottomStatusLabel.Visible = true;
        bottomStatusLabel.Text = $"Um die {distinctHitzgiReceivers} Personen zu adressieren würden {hitzgiAmount} Hitzgis benötigt.";
        SaveCurrentPriorityList();
    }

    private List<Group> GetCheckedGroups()
    {
        return groupsCheckedListBox.CheckedItems.Cast<Group>().ToList();
    }

    private void ExcelButtonOnClick(object sender, EventArgs e)
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
            MessageBox.Show($"Excel file konnte nicht gespeichert werden. Wende dich an den Ersteller des Programs.\nError: \"{ex}\"");
            _log.Error("Excel file could not be saved", ex);
        }
    }

    private void GenerateAndSaveExcelFile(string fileName)
    {
        var selectedGroups = GetCheckedGroups();
        var distinctPeople = _hitzgiAmountCalculator.GetPersonsDistinct(selectedGroups).ToArray();
        var groupPriorities = GetUserSetGroupPriority();

        Dictionary<Person, Group> prioritizedPeopleGroupAssociation =
            AssociateGroupsToPeopleAccordingToThePriorityList(distinctPeople, selectedGroups, groupPriorities.ToDictionary(x => x.Key, x => x.Value.Item1));

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
        _log.Info($"Excel file successfully created at \"{fileName}\"");
        Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
    }

    private Dictionary<string, Tuple<int, bool>> GetUserSetGroupPriority()
    {
        return groupsCheckedListBox.Items.Cast<Group>()
            .ToDictionary(
                group => group.Id,
                group => Tuple.Create(_groups.Count - _groups.IndexOf(group), //Indexes of _groups are in sync with the ones in groupsCheckedListBox
                    GetCheckedGroups().Contains(group))
            );
    }

    private Dictionary<Person, Group> AssociateGroupsToPeopleAccordingToThePriorityList(IEnumerable<Person> distinctPeople, IEnumerable<Group> selectedGroups, Dictionary<string, int> groupPriorities)
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
                    if (!groupPriorities.TryGetValue(groupWherePersonIsIn.Id, out int priority))
                    {
                        priority = -1; //groupPriorities only contains selected groups, if group is not selected set priority to a low value
                    }
                    return priority;
                }));
    }

    private void PriorityUpButton_Click(object sender, EventArgs e)
    {
        MoveGroupRelativeToItsPosition(-1);
    }

    private void PriorityDownButton_Click(object sender, EventArgs e)
    {
        MoveGroupRelativeToItsPosition(1);
    }

    private void MoveGroupRelativeToItsPosition(int positionsToMove)
    {
        if (!IsAnyElementSelected(groupsCheckedListBox))
        {
            return;
        }

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

        SaveCurrentPriorityList();
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
        GroupsCheckedListBox_SelectedIndexChanged(null, null);
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
        var groupPriorities = GetUserSetGroupPriority();

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
            _log.Info("Save of group priority list was successful");
        }
    }

    private bool TryLoadPriorityList(out Dictionary<string, Tuple<int, bool>> groupPriorityList)
    {
        groupPriorityList = null;
        try
        {
            groupPriorityList = FileUtil.LoadGroupPriorities();
            _log.Info("Group priorities successfully loaded from file");
            return true;
        }
        catch (JsonReaderException ex)
        {
            _log.Warn("Group priorities could not be loaded", ex);
            //something is wrong with the json file, ignore it
        }
        catch (IOException ex)
        {
            _log.Warn("Group priorities could not be loaded", ex);
            //something is wrong with the file, ignore it
        }
        return false;
    }

    private void CopyTnMobileButton_Click(object sender, EventArgs e)
    {
        var selectedGroups = GetCheckedGroups();
        var personsDistinct = _hitzgiAmountCalculator.GetPersonsDistinct(selectedGroups);

        var phoneNumbers = personsDistinct
            .Where(DoesNotHaveLeaderRole)
            .SelectMany(p => p.PhoneNumbers)
            .Where(pn => pn.Label != "Privat")
            .Select(pn => pn.Number)
            .Distinct().ToArray();

        string phoneNumberString = string.Join("; ", phoneNumbers);

        Clipboard.SetText(phoneNumberString);

        bottomStatusLabel.Text = $"{phoneNumbers.Length} Handynummern in Zwischenablage kopiert";

    }

    private static bool DoesNotHaveLeaderRole(Person person)
    {
        return !person.Roles.Any(
            role =>
                role.RoleType is "Einheitsleiter" or "Mitleiter" or "Adressverwalter");
    }
}