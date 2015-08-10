using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	/// <summary>
	/// Contains information which are linked to a group in a group information request with <see cref="UrlConstants.GroupDetailsUrlFormatString"/>.
	/// </summary>
	internal class GrouplinksJson
	{
		/// <summary>
		/// Gets or sets the layer group of this group. This could be the group itself if it is a layer group.
		/// Layergroups are: "Abteilung", "Region", "Kantonalverband", "Bund".
		/// </summary>
		[JsonProperty("layer_group")]
		internal string LayerGroup { get; set; }

		/// <summary>
		/// Gets or sets the ids of the identifier of the groups which are hirachicaly above this group. Ordere so that the most top group is the first entry.
		/// This array contains also the identifier of the current group itself.
		/// </summary>
		[JsonProperty("hierarchies")]
		internal string[] Hierarchies { get; set; }

		/// <summary>
		/// Gets or sets the identifier of all child groups.
		/// </summary>
		[JsonProperty("children")]
		internal string[] Children { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the parent group.
		/// </summary>
		[JsonProperty("parent")]
		internal string ParentGroup { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the contact person for this group.
		/// </summary>
		[JsonProperty("contact")]
		internal string Contact { get; set; }

		/// <summary>
		/// Gets or sets the identifier of person who created this group.
		/// </summary>
		[JsonProperty("creator")]
		internal string Creator { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the person who updated last this group.
		/// </summary>
		[JsonProperty("updater")]
		internal string Updater { get; set; }
	}
}