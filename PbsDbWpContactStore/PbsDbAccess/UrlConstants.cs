using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbsDbAccess
{
	public static class UrlConstants
	{
		public const string JsonMimeType = "application/json";

		public const string BaseUrl = "https://db.scout.ch/";

		#region Login

		public const string ReadTokenUrl = "/users/sign_in";
		public const string GenerateTokenUrl = "/users/sign_in";
		public const string DeleteTokenUrl = "/users/sign_in";
		public const string EmailFormDataString = "person[email]";
		public const string PasswortFormDataString = "person[password]";
		public const string EmailHeaderString = "X-User-Email";
		public const string AuthentificationTokenHeaderString = "X-User-Token"; 

		#endregion

		#region Data

		public const string GroupUrlFormatString = "/groups/{0}.json";
		public const string PersonsOfGroupUrlFormatString = "/groups/{0}/people.json";

		#endregion
	}
}
