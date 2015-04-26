using System;
using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class GroupJson
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("layer")]
		public bool Layer { get; set; }

		[JsonProperty("group_type")]
		public string GroupType { get; set; }

		[JsonProperty("short_name")]
		public string ShortName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("zip_code")]
		public object ZipCode { get; set; }

		[JsonProperty("town")]
		public string Town { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("pbs_shortname")]
		public object PbsShortname { get; set; }

		[JsonProperty("website")]
		public string Website { get; set; }

		[JsonProperty("bank_account")]
		public string BankAccount { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty("links")]
		public LinksJson Links { get; set; }

		[JsonProperty("deleted_at")]
		public DateTime DeletedAt { get; set; }

	}
}