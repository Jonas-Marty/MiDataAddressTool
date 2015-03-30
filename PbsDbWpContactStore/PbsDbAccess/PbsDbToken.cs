namespace PbsDbAccess
{
	public class PbsDbToken
	{
		public string Value { get; set; }

		public PbsDbToken(string tokenString)
		{
			Value = tokenString;
		}
	}
}
