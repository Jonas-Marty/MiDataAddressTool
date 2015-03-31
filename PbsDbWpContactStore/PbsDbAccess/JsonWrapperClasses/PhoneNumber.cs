using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class PhoneNumber
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("number")]
		public string Number { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("_public")]
		public bool IsPublic { get; set; }
	}
}