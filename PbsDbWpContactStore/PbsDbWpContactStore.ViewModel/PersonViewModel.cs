using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PbsDbWpContactStore.Model;
using PbsDbWpContactStore.ViewModel.Annotations;

namespace PbsDbWpContactStore.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged;
		
	    private string _scoutName;
	    public string PersonScoutName
	    {
			get { return _scoutName; }
		    set
		    {
			    this._scoutName = value;
			    OnPropertyChanged();
		    }
	    }

		private string _name;
		public string PersonName
		{
			get { return _name; }
			set
			{
				this._scoutName = value;
				OnPropertyChanged();
			}
		}


		private string _firstName;
		public string PersonFirstName
		{
			get { return _firstName; }
			set
			{
				this._scoutName = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Person> PeopleCollection { get; set; }

	    public PersonViewModel()
	    {
		    PeopleCollection = new ObservableCollection<Person>(new People());
		    this.PersonScoutName = "ScoutName";
		    this.PersonName = "Name";
		    this.PersonFirstName = "Firstname";
	    }
			
		[NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    var handler = PropertyChanged;
		    if (handler != null) 
				handler(this, new PropertyChangedEventArgs(propertyName));
	    }
    }
}
