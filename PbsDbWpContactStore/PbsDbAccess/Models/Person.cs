using System;
using PbsDbAccess.JsonWrapperClasses;

namespace PbsDbAccess.Models
{
	public class Person
	{
		public string Id { get; set; }

		public string Type { get; set; }

		public string Href { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Nickname { get; set; }

		public string CompanyName { get; set; }

		public bool Company { get; set; }

		public string Email { get; set; }

		public string AuthenticationToken { get; set; }

		public string Address { get; set; }

		public string ZipCode { get; set; }

		public string Town { get; set; }

		public string Country { get; set; }

		public string Picture { get; set; }

		public PersonLinksJson Links { get; set; }

		public string Birthday { get; set; }

		public string Gender { get; set; }

		public string AdditionalInformation { get; set; }

		public string PbsNumber { get; set; }

		public string JsNumber { get; set; }

		public string SalutationValue { get; set; }

		public string CorrespondenceLanguage { get; set; }

		public object GradeOfSchool { get; set; }

		public bool HasBrotherAndSisters { get; set; }

		public string EntryDate { get; set; }

		public object LeavingDate { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }
	}
}