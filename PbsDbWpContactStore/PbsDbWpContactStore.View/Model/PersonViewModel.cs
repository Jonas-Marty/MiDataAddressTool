using System;
using System.Collections.Generic;
using PbsDbAccess.Models;

namespace PbsDbWpContactStore.View.Model
{
    public class PersonViewModel
    {
        private readonly Person _person;

        public PersonViewModel(Person person)
        {
            _person = person;
        }

        public string DisplayName
        {
            get
            {
                string displayName = $"{FirstName} {LastName}";
                if (!string.IsNullOrWhiteSpace(Nickname))
                {
                    displayName += $" / {Nickname}";
                }
                return displayName;
            }
        }

        public string Id => _person.Id;

        public string Href => _person.Href;

        public string FirstName => _person.FirstName;

        public string LastName => _person.LastName;

        public string Nickname => _person.Nickname;

        public string CompanyName => _person.CompanyName;

        public string Email => _person.Email;

        public string Address => _person.Address;

        public string ZipCodeTown => $"{ZipCode} {Town}";

        public string ZipCode => _person.ZipCode;

        public string Town => _person.Town;

        public string Picture => _person.Picture;

        public IEnumerable<AdditionalEmail> AdditionalEmails => _person.AdditionalEmails;

        public IEnumerable<Role> Roles => _person.Roles;

        public IEnumerable<PhoneNumber> PhoneNumbers => _person.PhoneNumbers;

        public DateTime? Birthday => _person.Birthday;

        /// <summary>
        /// Gets or sets the gender. "m" is for male and "w" for woman. An empty string stands for "Unknown".
        /// </summary>
        public string Gender => _person.Gender;

        public string AdditionalInformation => _person.AdditionalInformation;

        /// <summary>
        /// Gets or sets the primary group identifier.
        /// </summary>
        /// <value>
        /// The primary group.
        /// </value>
        public string PrimaryGroup => _person.PrimaryGroup;
    }
}