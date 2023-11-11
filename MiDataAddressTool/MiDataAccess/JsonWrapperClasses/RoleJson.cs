using System;
using Newtonsoft.Json;

namespace MiDataAccess.JsonWrapperClasses;

/// <summary>
/// Contains information of a role which the user has. The group where this role aplies is saved in the <see cref="RoleLinksJson"/> property.
/// </summary>
internal class RoleJson
{
    /// <summary>
    /// Gets or sets the identifier of the role. This is identifier is unique for every entry.
    /// </summary>
    [JsonProperty("id")]
    internal string Id { get; set; }
		
    /// <summary>
    /// Gets or sets the type of the role. This is a string property which contains a word describing the role. i.g.: "Rover".
    /// </summary>
    /// <remarks>
    /// All roles are listed here https://www.dropbox.com/sh/gycyx2r0ookv9du/ZW4_DZLNlb in the document "Funktionen_xx_xxx...".
    /// Alternatively they are listed in the github repository in the README.rdoc in https://github.com/hitobito/hitobito_pbs.
    /// </remarks>
    [JsonProperty("role_type")]
    internal string RoleType { get; set; }
		
    /// <summary>
    /// Gets or sets the label. It is currently always an empty string.
    /// </summary>
    [JsonProperty("label")]
    internal string Label { get; set; }

    /// <summary>
    /// Gets or sets the date when this role has been created.
    /// </summary>
    [JsonProperty("created_at")]
    internal DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date when this role has been updated.
    /// </summary>
    /// <value>
    /// The updated at.
    /// </value>
    [JsonProperty("updated_at")]
    internal DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date when this role has been deleted. If the is not deleted the value is null.
    /// </summary>
    [JsonProperty("deleted_at")]
    internal DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Gets or sets the linked role information. It contains the group to where this role belongs.
    /// </summary>
    [JsonProperty("links")]
    internal RoleLinksJson Links { get; set; }
}