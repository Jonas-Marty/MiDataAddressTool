namespace PbsDbAccess.Models
{
	public class LoggedinUserInformation
	{
		public string Id { get; set; }

		public string Email { get; set; }

		public string Token { get; set; }

		public string PrimaryGroupId { get; set; }

		public string PrimaryGroupType { get; set; }

		public string LastName { get; set; }

		public string FirstName { get; set; }

		public string Nickname { get; set; }
	}
}
