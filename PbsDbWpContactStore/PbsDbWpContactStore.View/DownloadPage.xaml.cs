using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using PbsDbAccess;
using PbsDbAccess.Models;
using PbsDbWpContactStore.View.Common;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PbsDbWpContactStore.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class DownloadPage
	{
	    public DownloadPage()
		{
			InitializeComponent();
		}

	    protected override void OnNavigatedTo(NavigationEventArgs e)
	    {
	        base.OnNavigatedTo(e);
            PbsDbWebAccess access = e.Parameter as PbsDbWebAccess;
            if (access != null)
            {
                var task = DownloadData(access);
                task.ContinueWith(async t =>
                {
                    if (!t.IsFaulted)
                    {
                        await Dispatcher.RunAsync(CoreDispatcherPriority.High, () => Frame.Navigate(typeof(MainPage)));
                    }
                    else
                    {
                        throw new NotImplementedException("Download failed, do something here");
                    }
                }); //Todo check for errors in t
            }
        }

	    protected override void LoadState(object sender, LoadStateEventArgs e)
	    {
	    }

	    protected override void SaveState(object sender, SaveStateEventArgs e)
		{
		}

		private async Task DownloadData(PbsDbWebAccess pbsDbAccess)
		{
			var groups = (await pbsDbAccess.RecieveAllGroupsFromLayerGroupRecursiveAsync()).ToList();

			List<Person> people = new List<Person>();

			foreach (var group in groups)
			{
				var peopleOfGroup = await pbsDbAccess.RecievePersonsOfGroupAsync(group.Id);

				foreach (var personOfGroup in peopleOfGroup)
				{
					Person existingPerson = people.FirstOrDefault(person => person.Id == personOfGroup.Id);
					//When person alread in another group, add roles of the current group to the person
					//no need to add it again
					if (existingPerson != null)
					{
						existingPerson.Roles = existingPerson.Roles.Concat(personOfGroup.Roles);
					}
					else // otherwise add the person to the list
					{
						people.Add(personOfGroup);
					}
				}

				Debug.WriteLine($"Personen von {group.Name} geladen");
			}

		    Debug.WriteLine("Personen laden abgeschlossen");
			
			await DataManager.SaveGroupsAsync(groups.ToList());
			await DataManager.SavePeopleAsync(people);
			await ContactManager.SetContactsAsync(people);

			Debug.WriteLine("Alle Kontakte dem ContactStore hinzugefügt");
		}
	}
}
