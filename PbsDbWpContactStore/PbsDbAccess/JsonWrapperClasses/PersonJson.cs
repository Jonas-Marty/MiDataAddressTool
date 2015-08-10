using System;
using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	/// <summary>
	/// Contains the information of a person of the PBS Database.
	/// </summary>
	internal class PersonJson
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[JsonProperty("id")]
		internal string Id { get; set; }

		/// <summary>
		/// Gets or sets the type. Is always set to "people". 
		/// </summary>
		/// <remarks>
		/// Probably exported just because it exists in their db.
		/// </remarks>
		[JsonProperty("type")]
		internal string Type { get; set; }

		/// <summary>
		/// Gets or sets the url to this person.
		/// </summary>
		[JsonProperty("href")]
		internal string Href { get; set; }

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		[JsonProperty("first_name")]
		internal string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		[JsonProperty("last_name")]
		internal string LastName { get; set; }

		/// <summary>
		/// Gets or sets the nickname (scout name, Pfadiname).
		/// </summary>
		[JsonProperty("nickname")]
		internal string Nickname { get; set; }

		/// <summary>
		/// Gets or sets the name of the company. Praciticaly only set when <see cref="IsCompany"/> is set to <c>true</c>.
		/// </summary>
		[JsonProperty("company_name")]
		internal string CompanyName { get; set; }


		/// <summary>
		/// Gets or sets a value indicating whether this instance is as company or a person.
		/// </summary>
		[JsonProperty("company")]
		internal bool IsCompany { get; set; }

		/// <summary>
		/// Gets or sets the email. This email is unique in the whole system.
		/// </summary>
		[JsonProperty("email")]
		internal string Email { get; set; }

		/// <summary>
		/// Gets or sets the authentication token. Only set in <see cref="UrlConstants.ReadTokenUrl"/> or <see cref="UrlConstants.GenerateTokenUrl"/> response.
		/// </summary>
		[JsonProperty("authentication_token")]
		internal string AuthenticationToken { get; set; }

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		[JsonProperty("address")]
		internal string Address { get; set; }

		/// <summary>
		/// Gets or sets the zip code.
		/// </summary>
		[JsonProperty("zip_code")]
		internal string ZipCode { get; set; }

		/// <summary>
		/// Gets or sets the town.
		/// </summary>
		[JsonProperty("town")]
		internal string Town { get; set; }

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		[JsonProperty("country")]
		internal string Country { get; set; }

		/// <summary>
		/// Gets or sets the url to the picture of the user.
		/// </summary>
		/// <remarks>
		/// Is always set, but it may contains a default picture.
		/// </remarks>
		[JsonProperty("picture")]
		internal string Picture { get; set; }

		/// <summary>
		/// Gets or sets the linked information of this person. It contains: phone numbers, additional emails, roles, creator, updator, primary group identifier.
		/// In context of a request for all persons of a group, the creator, updator and primary group identifier wil not be set.
		/// </summary>
		[JsonProperty("links")]
		internal PersonLinksJson Links { get; set; }

		/// <summary>
		/// Gets or sets the birthday. Only set in request to <see cref="UrlConstants.PersonDetailsUrlFormatString"/>.
		/// </summary>
		[JsonProperty("birthday")]
		internal DateTime? Birthday { get; set; }

		/// <summary>
		/// Gets or sets the gender. "m" is for male and "w" for woman. An empty string stands for "Unknown".
		/// </summary>
		[JsonProperty("gender")]
		internal string Gender { get; set; }

		/// <summary>
		/// Gets or sets the additional information.
		/// </summary>
		[JsonProperty("additional_information")]
		internal string AdditionalInformation { get; set; }

		/// <summary>
		/// Gets or sets the PBS number. This number is generated from the PBS database.
		/// </summary>
		[JsonProperty("pbs_number")]
		internal string PbsNumber { get; set; }

		/// <summary>
		/// Gets or sets the J+S number. This number is fount on a J+S identification card that you get when you make a leader course.
		/// </summary>
		[JsonProperty("j_s_number")]
		internal string JsNumber { get; set; }

		/// <summary>
		/// Gets or sets the salutation value.
		/// </summary>
		[JsonProperty("salutation_value")]
		internal string SalutationValue { get; set; }

		/// <summary>
		/// Gets or sets the correspondence language.
		/// </summary>
		[JsonProperty("correspondence_language")]
		internal string CorrespondenceLanguage { get; set; }

		/// <summary>
		/// Gets or sets the grade of school.
		/// </summary>
		[JsonProperty("grade_of_school")]
		internal string GradeOfSchool { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this person has brothers and sisters ins the pfadi.
		/// </summary>
		[JsonProperty("brother_and_sisters")]
		internal bool HasBrotherAndSisters { get; set; }

		/// <summary>
		/// Gets or sets the entry date.
		/// </summary>
		[JsonProperty("entry_date")]
		internal DateTime? EntryDate { get; set; }

		/// <summary>
		/// Gets or sets the leaving date.
		/// </summary>
		[JsonProperty("leaving_date")]
		internal DateTime? LeavingDate { get; set; }

		/// <summary>
		/// Gets or sets the datetime when this person was created.
		/// </summary>
		[JsonProperty("created_at")]
		internal DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the datetime when this person was updated last.
		/// </summary>
		[JsonProperty("updated_at")]
		internal DateTime UpdatedAt { get; set; }
	}
}