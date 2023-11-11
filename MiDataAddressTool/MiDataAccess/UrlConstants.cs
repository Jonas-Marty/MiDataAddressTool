namespace MiDataAccess;

/// <summary>
/// Contains constants for urls of the PBS database.
/// </summary>
/// <remarks>
/// Use the URLs together with the <see cref="BaseUrl"/>.
/// </remarks>
public static class UrlConstants
{
    /// <summary>
    /// The json MIME type string constant.
    /// </summary>
    public const string JsonMimeType = "application/json";

    /// <summary>
    /// The base URL for all urls.
    /// </summary>
    public const string BaseUrl = "https://db.scout.ch/de/";
    
    #region Data

    /// <summary>
    /// The group URL format string for getting the data of a group. Needs the group identifier for parameter {0}.
    /// </summary>
    public const string GroupDetailsUrlFormatString = "/groups/{0}.json";

    /// <summary>
    /// The URL format string for getting the people of a group. Needs the group identifier for parameter {0}.
    /// </summary>
    public const string PersonsOfGroupUrlFormatString = "/groups/{0}/people.json";

    /// <summary>
    /// The URL format string for getting the details of a person. Needs the group identifier for parameter {0} and de person identifier for parametter {1}.
    /// </summary>
    public const string PersonDetailsUrlFormatString = "/groups/{0}/people/{1}.json";

    #endregion
}