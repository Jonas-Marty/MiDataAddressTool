using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MiDataAccess.Models;

/// <summary>
/// Contains the information of a person of the PBS Database.
/// </summary>
[DebuggerDisplay("Person: {Id} - {FirstName} - {LastName} - {Nickname}")]
public class Person
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the url to this person.
    /// </summary>
    public string Href { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the nickname (scout name, Pfadiname).
    /// </summary>
    public string Nickname { get; set; }

    /// <summary>
    /// Gets or sets the name of the company. Praciticaly only set when <see cref="IsCompany"/> is set to <c>true</c>.
    /// </summary>
    /// <value>
    /// The name of the company.
    /// </value>
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is as company or a person.
    /// </summary>
    public bool IsCompany { get; set; }

    /// <summary>
    /// Gets or sets the email. This email is unique in the whole system.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the authentication token.
    /// </summary>
    public string AuthenticationToken { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the zip code.
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// Gets or sets the town.
    /// </summary>
    public string Town { get; set; }

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Gets or sets the url to the picture of the user.
    /// </summary>
    /// <remarks>
    /// Is always set, but it may contains a default picture.
    /// </remarks>
    public string Picture { get; set; }
		
    /// <summary>
    /// Gets or sets the additional emails.
    /// </summary>
    public IEnumerable<AdditionalEmail> AdditionalEmails { get; set; }

    /// <summary>
    /// Gets or sets the roles.
    /// </summary>
    public IEnumerable<Role> Roles { get; set; }

    /// <summary>
    /// Gets or sets the phone numbers.
    /// </summary>
    public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

    /// <summary>
    /// Gets or sets the birthday.
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Gets or sets the gender. "m" is for male and "w" for woman. An empty string stands for "Unknown".
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Gets or sets the additional information.
    /// </summary>
    public string AdditionalInformation { get; set; }

    /// <summary>
    /// Gets or sets the PBS number.
    /// </summary>
    public string PbsNumber { get; set; }

    /// <summary>
    /// Gets or sets the J+S number. This number is fount on a J+S identification card that you get when you make a leader course.
    /// </summary>
    public string JsNumber { get; set; }

    /// <summary>
    /// Gets or sets the salutation value.
    /// </summary>
    public string SalutationValue { get; set; }

    /// <summary>
    /// Gets or sets the correspondence language.
    /// </summary>
    public string CorrespondenceLanguage { get; set; }

    /// <summary>
    /// Gets or sets the grade of school.
    /// </summary>
    public string GradeOfSchool { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this person has brothers and sisters ins the pfadi.
    /// </summary>
    public bool HasBrotherAndSisters { get; set; }

    /// <summary>
    /// Gets or sets the entry date.
    /// </summary>
    public DateTime? EntryDate { get; set; }

    /// <summary>
    /// Gets or sets the leaving date.
    /// </summary>
    public DateTime? LeavingDate { get; set; }

    /// <summary>
    /// Gets or sets the datetime when this person was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the datetime when this person was updated last.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the person who created this person.
    /// </summary>
    public string Creator { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the person who updated last this person.
    /// </summary>
    public string Updater { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the primary group of this person.
    /// </summary>
    public string PrimaryGroup { get; set; }
}