using System;
using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class PersonJson
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		[JsonProperty("company_name")]
		public string CompanyName { get; set; }

		[JsonProperty("company")]
		public bool Company { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("authentication_token")]
		public string AuthenticationToken { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("zip_code")]
		public string ZipCode { get; set; }

		[JsonProperty("town")]
		public string Town { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("picture")]
		public string Picture { get; set; }

		[JsonProperty("links")]
		public PersonLinksJson Links { get; set; }

		[JsonProperty("birthday")]
		public string Birthday { get; set; }

		[JsonProperty("gender")]
		public string Gender { get; set; }

		[JsonProperty("additional_information")]
		public string AdditionalInformation { get; set; }

		[JsonProperty("pbs_number")]
		public string PbsNumber { get; set; }

		[JsonProperty("j_s_number")]
		public string JsNumber { get; set; }

		[JsonProperty("salutation_value")]
		public string SalutationValue { get; set; }

		[JsonProperty("correspondence_language")]
		public string CorrespondenceLanguage { get; set; }

		[JsonProperty("grade_of_school")]
		public object GradeOfSchool { get; set; }

		[JsonProperty("brother_and_sisters")]
		public bool HasBrotherAndSisters { get; set; }

		[JsonProperty("entry_date")]
		public string EntryDate { get; set; }

		[JsonProperty("leaving_date")]
		public object LeavingDate { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }
	}
}