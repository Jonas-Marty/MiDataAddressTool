using PbsDbWpContactStore.View.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Phone.PersonalInformation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MoreLinq;
using PbsDbAccess;
using PbsDbAccess.Models;

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

		protected override void LoadState(object sender, LoadStateEventArgs e)
		{
			PbsDbWebAccess access = e.NavigationParameter as PbsDbWebAccess;
			if (access != null)
			{
				var task = DownloadData(access);
				task.ContinueWith((t) => Frame.Navigate(typeof (MainPage))); //Todo check for errors in t
			}
		}

		protected override void SaveState(object sender, SaveStateEventArgs e)
		{
			throw new NotImplementedException();
		}

		private async Task DownloadData(PbsDbWebAccess pbsDbAccess)
		{
			var groups = await pbsDbAccess.RecieveAllGroupsFromLayerGroupRecursiveAsync();

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
			
			await DataManager.SaveContacts(people);
			await ContactManager.SetContacts(people);

			Debug.WriteLine("Alle Kontakte dem ContactStore hinzugefügt");
		}
	}
}
