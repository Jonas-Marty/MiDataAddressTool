using System.Diagnostics;

namespace MiDataAccess.Models;

/// <summary>
/// Contains information of a group.
/// </summary>
[DebuggerDisplay("{Id} - {Name},nq")]
public class Group
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this group is a layer group or not.
    /// "Abteilung", "Region", "Kantonalverband" and "Bund" groups are always layer groups.
    /// </summary>
    public bool IsLayerGroup { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the parent group.
    /// </summary>
    public string ParentGroupId { get; set; }

    /// <summary>
    /// Gets or sets the layer group of this group. This could be the group itself if it is a layer group.
    /// Layergroups are: "Abteilung", "Region", "Kantonalverband", "Bund".
    /// </summary>
    public string LayerGroupId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of all child groups.
    /// </summary>
    public string[] ChildGroupIds { get; set; }
}