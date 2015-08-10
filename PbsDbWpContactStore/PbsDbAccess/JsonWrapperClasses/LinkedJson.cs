using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	/// <summary>
	/// Contains diffrent informations which are linked to the people in the RootObject.
	/// </summary>
	internal class LinkedJson
	{
		/// <summary>
		/// Gets or sets an array of phone numbers which are linked the the people.
		/// They are linked with an ID.
		/// </summary>
		[JsonProperty("phone_numbers")]
		internal PhoneNumberJson[] PhoneNumbers { get; set; }

		/// <summary>
		/// Gets or sets an array of additional emailadresses which are linked the the people.
		/// They are linked with an ID.
		/// Additional email adresses ar for example "Arbeit", "Privat 2".
		/// </summary>
		[JsonProperty("additional_emails")]
		internal AdditionalEmailJson[] AdditionalEmail { get; set; }

		/// <summary>
		/// Gets or sets an array of groups. Contains the linked groups in a groupinformation request, these are
		/// any Subgroups and all parent groups.
		/// </summary>
		[JsonProperty("groups")]
		internal GroupJson[] Groups { get; set; }

		/// <summary>
		/// Gets or sets the roles of a person.
		/// </summary>
		[JsonProperty("roles")]
		internal RoleJson[] Roles { get; set; }
	}
}