using Newtonsoft.Json;

namespace MiDataAccess.JsonWrapperClasses;

/// <summary>
/// The root object which contain all data returned from the database.
/// Not all fields are used in every response, but the format of the response is always identical, 
/// so we can use allways the same root object and just read the information we need.
/// </summary>
internal class RootObjectJson
{
    /// <summary>
    /// Gets or sets a an array of Persons.
    /// </summary>
    [JsonProperty("people")]
    internal PersonJson[] People { get; set; }

    /// <summary>
    /// Gets or sets the linked information.
    /// </summary>
    [JsonProperty("linked")]
    internal LinkedJson Linked { get; set; }

    /// <summary>
    /// Gets or sets an array of groups in a <see cref="UrlConstants.GroupDetailsUrlFormatString"/> request.
    /// It is only filled with one entry.
    /// </summary>
    [JsonProperty("groups")]
    internal GroupJson[] Groups { get; set; }
}