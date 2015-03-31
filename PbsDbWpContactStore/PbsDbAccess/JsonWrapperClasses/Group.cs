using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class Group
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("group_type")]
		public string GroupType { get; set; }
	}
}