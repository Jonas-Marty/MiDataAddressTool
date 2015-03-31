using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class RoleLinks
	{
		[JsonProperty("group")]
		public string Group { get; set; }

		[JsonProperty("layer_group")]
		public string LayerGroup { get; set; }
	}
}