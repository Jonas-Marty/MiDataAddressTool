using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	public class LinksJson
	{
		[JsonProperty("group")]
		public string Group { get; set; }

		[JsonProperty("layer_group")]
		public string LayerGroup { get; set; }

		[JsonProperty("hierarchies")]
		public string[] Hierarchies { get; set; }

		[JsonProperty("children")]
		public string[] Children { get; set; }

		[JsonProperty("parent")]
		public string ParentGroup { get; set; }
	}
}