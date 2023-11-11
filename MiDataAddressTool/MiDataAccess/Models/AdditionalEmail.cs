namespace MiDataAccess.Models;

/// <summary>
/// Contains information of an additonal email adress.
/// </summary>
/// <remarks>
/// Each person has an main email adress (<see cref="Person.Email"/>).
/// All other email adresses are saved as <see cref="AdditionalEmail"/> and referenced in <see cref="Person.AdditionalEmails"/>.
/// </remarks>
/// <example>
/// As example you could save the email of the parents or the company email.
/// </example>
public class AdditionalEmail
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the label. e.g.: "Vater", "Geschäft".
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this email adress is public for all peoeple with reading rights
    /// or only for people of the same group as the user.
    /// </summary>
    public bool IsPublic { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this email adress is added to the list if you export the email adresses.
    /// If set to <c>false</c> only the <see cref="Person.Email"/> will be used.
    /// </summary>
    public bool Mailings { get; set; }
}