using System.Collections.ObjectModel;
using PbsDbAccess.Models;

namespace PbsDbWpContactStore.View.Model
{
    public class GroupWithPeopleModel
    {
        public string Group { get; set; }

        public ObservableCollection<PersonViewModel> People { get; set; }
    }
}