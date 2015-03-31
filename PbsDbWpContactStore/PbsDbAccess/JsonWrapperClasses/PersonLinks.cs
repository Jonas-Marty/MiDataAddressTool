using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class PersonLinks
	{
		[JsonProperty("phone_numbers")]
		public string[] PhoneNumbers { get; set; }

		[JsonProperty("roles")]
		public string[] Roles { get; set; }

		[JsonProperty("additional_emails")]
		public string[] AdditionalEmails { get; set; }

		[JsonProperty("creator")]
		public string Creator { get; set; }

		[JsonProperty("updater")]
		public string Updater { get; set; }

		[JsonProperty("primary_group")]
		public string PrimaryGroup { get; set; }
	}
}