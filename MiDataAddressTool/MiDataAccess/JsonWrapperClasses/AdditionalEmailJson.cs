using Newtonsoft.Json;

namespace MiDataAccess.JsonWrapperClasses;

/// <summary>
/// Contains information of an additonal email adress.
/// </summary>
/// <remarks>
/// Each person has an main email adress (<see cref="PersonJson.Email"/>).
/// All other email adresses are saved as <see cref="AdditionalEmailJson"/> an referenced in <see cref="PersonJson.Links"/>.
/// </remarks>
/// <example>
/// As example you could save the email of the parents or the company email.
/// </example>
internal class AdditionalEmailJson
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    [JsonProperty("id")]
    internal string Id { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    [JsonProperty("email")]
    internal string Email { get; set; }

    /// <summary>
    /// Gets or sets the label. e.g.: "Vater", "Geschäft".
    /// </summary>
    [JsonProperty("label")]
    internal string Label { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this email adress is public for all peoeple with reading rights
    /// or only for people of the same group as the user.
    /// </summary>
    [JsonProperty("_public")]
    internal bool IsPublic { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this email adress is added to the list if you export the email adresses.
    /// If set to <c>false</c> only the <see cref="PersonJson.Email"/> will be used.
    /// </summary>
    [JsonProperty("mailings")]
    internal bool Mailings { get; set; }
}