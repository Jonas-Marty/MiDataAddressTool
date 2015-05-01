namespace PbsDbAccess
{
	internal class LoggedinUserInformation
	{
		internal string Id { get; set; }

		internal string Email { get; set; }

		internal string Token { get; set; }

		public string PrimaryGroupId { get; set; }

		internal string PrimaryGroupType { get; set; }

		internal string LastName { get; set; }

		internal string FirstName { get; set; }

		internal string Nickname { get; set; }
	}
}
