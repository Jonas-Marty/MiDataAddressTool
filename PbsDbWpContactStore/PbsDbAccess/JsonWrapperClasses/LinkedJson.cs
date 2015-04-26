using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	/// <summary>
	/// Contains diffrent informations which are linked to the people in the RootObject.
	/// </summary>
	public class LinkedJson
	{
		/// <summary>
		/// Gets or sets an array of phone numbers which are linked the the people.
		/// They are linked with an ID.
		/// </summary>
		[JsonProperty("phone_numbers")]
		public PhoneNumberJson[] PhoneNumber { get; set; }

		/// <summary>
		/// Gets or sets an array of additional emailadresses which are linked the the people.
		/// They are linked with an ID.
		/// Additional email adresses ar for example "Arbeit", "Privat 2".
		/// </summary>
		[JsonProperty("additional_emails")]
		public AdditionalEmailJson[] AdditionalEmail { get; set; }


		[JsonProperty("groups")]
		public GroupJson[] Groups { get; set; }

		[JsonProperty("roles")]
		public RoleJson[] RolesJson { get; set; }
	}
}