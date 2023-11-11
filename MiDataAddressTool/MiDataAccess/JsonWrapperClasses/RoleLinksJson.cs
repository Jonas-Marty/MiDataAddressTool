using Newtonsoft.Json;

namespace MiDataAccess.JsonWrapperClasses;

/// <summary>
/// Contains linked information of a role of a person.
/// </summary>
internal class RoleLinksJson
{
    /// <summary>
    /// Gets or sets the identifier of the group where this role aplies.
    /// </summary>
    [JsonProperty("group")]
    internal string Group { get; set; }

    /// <summary>
    /// Gets or sets the identifier of layer group of the group where this role aplies.
    /// If the <see cref="Group"/> is a layer group, then this propertey equals to <see cref="Group"/>.
    /// </summary>
    [JsonProperty("layer_group")]
    internal string LayerGroup { get; set; }
}