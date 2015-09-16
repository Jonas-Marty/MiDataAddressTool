using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Phone.PersonalInformation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MoreLinq;
using PbsDbAccess;
using PbsDbAccess.Models;
using ContactAddress = Windows.Phone.PersonalInformation.ContactAddress;
using ContactStore = Windows.Phone.PersonalInformation.ContactStore;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace PbsDbWpContactStore.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			this.NavigationCacheMode = NavigationCacheMode.Required;
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			// TODO: Prepare page for display here.

			// TODO: If your application contains multiple pages, ensure that you are
			// handling the hardware Back button by registering for the
			// Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
			// If you are using the NavigationHelper provided by some templates,
			// this event is handled for you.

		}

		private async void loginButton_Click(object sender, RoutedEventArgs e)
		{
			loginProgressBar.Visibility = Visibility.Visible;

			PbsDbWebAccess access;
			try
			{
				access = await PbsDbWebAccess.CreateInstanceAsync(emailTextBox.Text, passwordBox.Password);
			}
			catch (InvalidLoginInformationException ex)
			{
				statusTextBlock.Text = ex.Message;
				statusTextBlock.Visibility = Visibility.Visible;
				return;
			}
			finally
			{
				loginProgressBar.Visibility = Visibility.Collapsed;
			}

			statusTextBlock.Visibility = Visibility.Visible;
			statusTextBlock.Text = "Successfull logged in";


			//var access = await PbsDbWebAccess.CreateInstanceAsync("wiwo@outlook.com", "J268210pfadi");

			/*
			var contactStore = await ContactStore.CreateOrOpenAsync();

			await contactStore.DeleteAsync();

			contactStore = await ContactStore.CreateOrOpenAsync();

			var groups = await access.RecieveAllGroupsFromLayerGroupRecursiveAsync();

			List<Person> people = new List<Person>();

			foreach (var group in groups)
			{
				people.AddRange(await access.RecievePersonsOfGroupAsync(group.Id));
				Debug.WriteLine($"Personen von {group.Name} geladen");
			}

			Debug.WriteLine("Personen laden abgeschlossen");

			var peopleDistinct = people.DistinctBy(p => p.Id);

			foreach (var person in peopleDistinct)
			{
				StoredContact contact = new StoredContact(contactStore);
				var properties = await contact.GetPropertiesAsync();
				properties.Add(KnownContactProperties.Nickname, person.Nickname);
				properties.Add(KnownContactProperties.FamilyName, person.LastName);
				properties.Add(KnownContactProperties.GivenName, person.FirstName);
				var contactAdress = new ContactAddress
				{
					Country = person.Country,
					Locality = person.Town,
					PostalCode = person.ZipCode,
					StreetAddress = person.Address
				};
				properties.Add(KnownContactProperties.Address, contactAdress);
				properties.Add(KnownContactProperties.Birthdate, new DateTimeOffset(person.Birthday ?? DateTime.Now)); //TODO fix
				properties.Add(KnownContactProperties.DisplayName, $"{person.FirstName} {person.LastName} v/o {person.Nickname}");
				if (person.PhoneNumbers.Any())
				{
					properties.Add(KnownContactProperties.Telephone, person.PhoneNumbers.First().Number);
				}
				if (person.PhoneNumbers.Count() > 1)
				{
					properties.Add(KnownContactProperties.MobileTelephone, person.PhoneNumbers.ElementAt(0).Number);
				}
				properties.Add(KnownContactProperties.Email, person.Email);
				var extendedProperties = await contact.GetExtendedPropertiesAsync();
				extendedProperties.Add("CPU", "krass");
				await contact.SaveAsync();
			}

			Debug.WriteLine("Alle Kontakte dem ContactStore hinzugefügt");

			*/
		}
	}
}
