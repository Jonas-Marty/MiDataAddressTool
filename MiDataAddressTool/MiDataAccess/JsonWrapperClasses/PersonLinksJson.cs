using Newtonsoft.Json;

namespace MiDataAccess.JsonWrapperClasses;

/// <summary>
/// Contains linked information of a person.
/// In context of a request for all people of a group, the <see cref="Creator"/>, <see cref="Updater"/> and <see cref="PrimaryGroup"/> properties are not set.
/// For those properies make a request to <see cref="UrlConstants.PersonDetailsUrlFormatString"/>
/// </summary>
internal class PersonLinksJson
{
    /// <summary>
    /// Gets or sets an array of identifiers of phone numbers.
    /// The phone numbers are saved under <see cref="LinkedJson.PhoneNumbers"/> in the <see cref="RootObjectJson"/>.
    /// </summary>
    [JsonProperty("phone_numbers")]
    internal string[] PhoneNumbers { get; set; }

    /// <summary>
    /// Gets or sets an array of identifiers of roles.
    /// The roles are saved under <see cref="LinkedJson.Roles"/> in the <see cref="RootObjectJson"/>.
    /// </summary>
    [JsonProperty("roles")]
    internal string[] Roles { get; set; }

    /// <summary>
    /// Gets or sets an array of identifiers of additional emails.
    /// The additions emails are saved under <see cref="LinkedJson.AdditionalEmail"/> in the <see cref="RootObjectJson"/>.
    /// </summary>
    [JsonProperty("additional_emails")]
    internal string[] AdditionalEmails { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the person who created this person.
    /// </summary>
    [JsonProperty("creator")]
    internal string Creator { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the person who updated last this person.
    /// </summary>
    [JsonProperty("updater")]
    internal string Updater { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the primary group of this person.
    /// </summary>
    [JsonProperty("primary_group")]
    internal string PrimaryGroup { get; set; }
}