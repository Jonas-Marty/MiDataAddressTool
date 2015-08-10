namespace PbsDbAccess
{
	/// <summary>
	/// Represents the authentification and basic data of a user of the PBS DB.
	/// </summary>
	internal class LoggedinUserInformation
	{
		/// <summary>
		/// Gets or sets the id
		/// </summary>
		internal string Id { get; set; }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		internal string Email { get; set; }

		/// <summary>
		/// Gets or sets the authentifiaction token to be sent with every request.
		/// </summary>
		internal string Token { get; set; }

		/// <summary>
		/// Gets or sets the id of the group which is marked as primary of the user.
		/// </summary>
		/// <value>
		/// The primary group identifier. It is a number as a string.
		/// </value>
		internal string PrimaryGroupId { get; set; }

		/// <summary>
		/// Gets or sets the type of the primary group.
		/// </summary>
		/// <value>
		/// The type of the primary group.
		/// </value>
		/// <example>
		/// "Bund", "Kantonalverband", "Abteilung", "Gremium", "Wölfe", "Biber", "Pfadi", "Elternrat", "Pio", "Rover", "Gruppe"
		/// </example>
		internal string PrimaryGroupType { get; set; }

		/// <summary>
		/// Gets or sets the last name of the user.
		/// </summary>
		internal string LastName { get; set; }

		/// <summary>
		/// Gets or set the first name of the user.
		/// </summary>
		internal string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the nickname (Scoutname, Pfadiname) of the user.
		/// </summary>
		internal string Nickname { get; set; }
	}
}
