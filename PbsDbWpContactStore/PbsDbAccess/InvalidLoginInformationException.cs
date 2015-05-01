using System;

namespace PbsDbAccess
{
	public class InvalidLoginInformationException : Exception
	{
		private const string DefaultMessage = "Passwort oder Email falsch.";

		public InvalidLoginInformationException()
			: this(DefaultMessage)
		{
		}

		public InvalidLoginInformationException(string message)
			: base(message)
		{
		}

		public InvalidLoginInformationException(string message, Exception inner)
			: base(message, inner)
		{
		}

	}
}