using System;
using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	/// <summary>
	/// Contains information of a group.
	/// </summary>
	/// <remarks>
	/// Only <see cref="Id"/>, <see cref="Name"/> and <see cref="GroupType"/> are returned in a response
	/// if it is a linked group. For detailed information, request the groupinformation directly with <see cref="UrlConstants.GroupDetailsUrlFormatString"/>.
	/// </remarks>
	internal class GroupJson
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[JsonProperty("id")]
		internal string Id { get; set; }

		/// <summary>
		/// Gets or sets the type. For a Group this property is always set to "groups". The idea of this property is unknown.
		/// </summary>
		[JsonProperty("type")]
		internal string Type { get; set; }

		/// <summary>
		/// Gets or sets the href.
		/// </summary>
		/// <value>
		/// The href.
		/// </value>
		[JsonProperty("href")]
		internal string Href { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[JsonProperty("name")]
		internal string Name { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this group is a layer group or not.
		/// "Abteilung", "Region", "Kantonalverband" and "Bund" groups are always layer groups.
		/// </summary>
		[JsonProperty("layer")]
		internal bool IsLayerGroup { get; set; }

		/// <summary>
		/// Gets or sets the type of the group.
		/// </summary>
		/// <value>
		/// Possible values: "Bund", "Kantonalverband", "Region" (Cors), "Abteilung", "Gremium", "Wölfe", "Biber", "Pfadi", "Elternrat", "Pio", "Rover", "Gruppe"
		/// </value>
		[JsonProperty("group_type")]
		internal string GroupType { get; set; }

		/// <summary>
		/// Gets or sets the short name of the group.
		/// </summary>
		/// <example>
		/// For "Pfadi Arth-Goldau" the short name is "PAG".
		/// </example>
		[JsonProperty("short_name")]
		internal string ShortName { get; set; }

		/// <summary>
		/// Gets or sets the email for contacting the group. This email is not bound to a person.
		/// </summary>
		/// <example>
		/// "al-pfadiarthgoldau@outlook.com"
		/// </example>
		[JsonProperty("email")]
		internal string Email { get; set; }

		/// <summary>
		/// Gets or sets the PBS shortname.
		/// </summary>
		/// <example>
		/// "SZ01"
		/// </example>
		[JsonProperty("pbs_shortname")]
		internal string PbsShortname { get; set; }

		/// <summary>
		/// Gets or sets the website url.
		/// </summary>
		[JsonProperty("website")]
		internal string Website { get; set; }

		/// <summary>
		/// Gets or sets the bank account.
		/// </summary>
		[JsonProperty("bank_account")]
		internal string BankAccount { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[JsonProperty("description")]
		internal string Description { get; set; }

		/// <summary>
		/// Gets or sets the DateTime when the group has been created at.
		/// </summary>
		[JsonProperty("created_at")]
		internal DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the DateTime when the group has been updated at.
		/// </summary>
		[JsonProperty("updated_at")]
		internal DateTime UpdatedAt { get; set; }

		/// <summary>
		/// Gets or sets the linked information. These are: Contact person, creator, updater, parent group, layer group, group hierarchies and child groups.
		/// </summary>
		[JsonProperty("links")]
		internal GrouplinksJson Grouplinks { get; set; }

		/// <summary>
		/// Gets or sets the DateTime when the group has been deleted at.
		/// </summary>
		/// <remarks>
		/// This property is null when the group has not been deleted.
		/// </remarks>
		[JsonProperty("deleted_at")]
		internal DateTime? DeletedAt { get; set; }

	}
}