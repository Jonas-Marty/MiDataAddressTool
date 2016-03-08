using System.Collections.ObjectModel;

namespace PbsDbWpContactStore.View.Model
{
    public class MainPageViewModel
    {
        public ObservableCollection<GroupWithPeopleModel> GroupsWithPeople { get; set; }
    }
}