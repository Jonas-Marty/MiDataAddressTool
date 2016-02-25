using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Phone.PersonalInformation;
using PbsDbAccess.Models;

namespace PbsDbWpContactStore.View
{
	public static class ContactManager
	{
		public static async Task SetContacts(IEnumerable<Person> contacts)
		{
			var contactStore = await ContactStore.CreateOrOpenAsync();

			await contactStore.DeleteAsync();

			contactStore = await ContactStore.CreateOrOpenAsync();

			foreach (var person in contacts)
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
				//add other properties
				//extendedProperties.Add("CPU", "krass");
				await contact.SaveAsync();
			}
		}
	}
}