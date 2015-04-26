using System;
using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class RoleJson
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("role_type")]
		public string RoleType { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty("deleted_at")]
		public DateTime? DeletedAt { get; set; }

		[JsonProperty("links")]
		public LinksJson Links { get; set; }
	}
}