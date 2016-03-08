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
        private const string NameOfHomeNumberField = "Privat";
        private const string NameOfMobilNumberField = "Mobil";
        private const string NameOfCompanyNumberField = "Arbeit";
        private const string NameOfFatherNumberField = "Vater";
        private const string NameOfMothereNumberField = "Mutter";

        public static async Task SetContactsAsync(IEnumerable<Person> contacts)
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
                properties.Add(KnownContactProperties.Address, new ContactAddress
                {
                    Country = person.Country ?? string.Empty,
                    Locality = person.Town,
                    PostalCode = person.ZipCode,
                    StreetAddress = person.Address
                });
                if (person.Birthday.HasValue)
                {
                    properties.Add(KnownContactProperties.Birthdate, new DateTimeOffset(person.Birthday.Value));

                }
                properties.Add(KnownContactProperties.DisplayName, $"{person.FirstName} {person.LastName} v/o {person.Nickname}");

                //TODO: Replace magic strings
                string homeNumber = person.PhoneNumbers.FirstOrDefault(number => number.Label == NameOfHomeNumberField)?.Number;
                string mobilNumber = person.PhoneNumbers.FirstOrDefault(number => number.Label == NameOfMobilNumberField)?.Number;
                string companyNumer = person.PhoneNumbers.FirstOrDefault(number => number.Label == NameOfCompanyNumberField)?.Number;
                string motherNumber = person.PhoneNumbers.FirstOrDefault(number => number.Label == NameOfMothereNumberField)?.Number;
                string fatherNumber = person.PhoneNumbers.FirstOrDefault(number => number.Label == NameOfFatherNumberField)?.Number;

                if (homeNumber != null)
                {
                    properties.Add(KnownContactProperties.Telephone, homeNumber);
                }
                if (mobilNumber != null)
                {
                    properties.Add(KnownContactProperties.MobileTelephone, mobilNumber);
                }
                if (companyNumer != null)
                {
                    properties.Add(KnownContactProperties.WorkTelephone, companyNumer);
                }

                properties.Add(KnownContactProperties.Email, person.Email);
                var additionEmail = person.AdditionalEmails.FirstOrDefault();
                if (additionEmail != null)
                {
                    properties.Add(KnownContactProperties.OtherEmail, additionEmail);
                }
                var extendedProperties = await contact.GetExtendedPropertiesAsync();

                if (motherNumber != null)
                {
                    extendedProperties.Add("Telefon Mutter", motherNumber);
                }
                if (fatherNumber != null)
                {
                    extendedProperties.Add("Telefon Vater", fatherNumber);
                }
                await contact.SaveAsync();
            }
        }
    }
}