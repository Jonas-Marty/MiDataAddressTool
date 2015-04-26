using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class AdditionalEmailJson
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("_public")]
		public bool Public { get; set; }

		[JsonProperty("mailings")]
		public bool Mailings { get; set; }
	}
}