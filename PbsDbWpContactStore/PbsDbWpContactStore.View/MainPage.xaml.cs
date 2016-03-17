using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PbsDbAccess.Models;
using PbsDbWpContactStore.View.Common;
using PbsDbWpContactStore.View.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace PbsDbWpContactStore.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private List<Person> People { get; set; }

        private List<Group> Groups { get; set; }

        private const string GroupsName = "Groups";

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void LoadState(object sender, LoadStateEventArgs e)
        {
            await LoadData();
        }

        protected override void SaveState(object sender, SaveStateEventArgs e)
        {
        }

        private async Task LoadData()
        {
            if (!await DataManager.DetermineIfSavedPeopleAreExistingAsync())
            {
                Frame.Navigate(typeof (LoginPage));
                return;
            }
            People = await DataManager.LoadPeopleAsync();
            Groups = await DataManager.LoadGroupsAsync();

            Debug.WriteLine($"{People.Count} Personen aus Speicher geladen");

            var personGroupeRoles =
                People
                    .Select(person => new PersonViewModel(person))
                    .SelectMany(person => person.Roles.Select(role => new { Person = person, Group = role.Group }));

            var groupsWithPeople = Groups.Select(group => new GroupWithPeopleModel
            {
                Group = group.Name,
                People = new ObservableCollection<PersonViewModel>(
                    personGroupeRoles.Where(personGroupRole => personGroupRole.Group == group.Id)
                        .Select(personGroupeRole => personGroupeRole.Person)
                    )
            });

            DefaultViewModel[GroupsName] = new MainPageViewModel { GroupsWithPeople = new ObservableCollection<GroupWithPeopleModel>(groupsWithPeople) };
        }

        private void settingAppBarButton_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof (ContactPage), e.ClickedItem);
        }
    }
}
