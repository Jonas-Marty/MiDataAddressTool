namespace PbsDbAccess
{
    /// <summary>
    /// Represents the authentification and basic data of a user of the PBS DB.
    /// </summary>
    internal class LoggedinUserInformation
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        internal string Email { get; set; }

        /// <summary>
        /// Gets or sets the authentifiaction token to be sent with every request.
        /// </summary>
        internal string UserToken { get; set; }

        public string ApiToken { get; internal set; }

        /// <summary>
        /// Gets or sets the id of the group which is marked as primary of the user.
        /// </summary>
        /// <value>
        /// The primary group identifier. It is a number as a string.
        /// </value>
        internal string PrimaryGroupId { get; set; }
    }
}
