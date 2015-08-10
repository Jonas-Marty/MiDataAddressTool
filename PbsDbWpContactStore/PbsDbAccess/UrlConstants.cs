using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbsDbAccess
{
	/// <summary>
	/// Contains constants for urls of the PBS database.
	/// </summary>
	/// <remarks>
	/// Use the URLs together with the <see cref="BaseUrl"/>.
	/// </remarks>
	public static class UrlConstants
	{
		/// <summary>
		/// The json MIME type string constant.
		/// </summary>
		public const string JsonMimeType = "application/json";

		/// <summary>
		/// The base URL for all urls.
		/// </summary>
		public const string BaseUrl = "https://db.scout.ch/";

		#region Login

		/// <summary>
		/// The URL to get the user token, with HTTP POST.
		/// </summary>
		public const string ReadTokenUrl = "/users/sign_in";

		/// <summary>
		/// The URL to generate the user token, with HTTP POST.
		/// </summary>
		public const string GenerateTokenUrl = "/users/token";

		/// <summary>
		/// The URL to delete the user token, with HTTP DELETE.
		/// </summary>
		public const string DeleteTokenUrl = "/users/sign_in";

		/// <summary>
		/// The term for the email field used in the POST for generating, recieving the token.
		/// </summary>
		public const string EmailFormDataString = "person[email]";

		/// <summary>
		/// The term for the passwort field used in the POST for generating, recieving the token.
		/// </summary>
		public const string PasswortFormDataString = "person[password]";

		/// <summary>
		/// The term for the email field used in the header for every request when the token is already known.
		/// </summary>
		public const string EmailHeaderString = "X-User-Email";

		/// <summary>
		/// The term for the token field used in the header for every request when the token is already known.
		/// </summary>
		public const string AuthentificationTokenHeaderString = "X-User-Token";

		#endregion

		#region Data

		/// <summary>
		/// The group URL format string for getting the data of a group. Needs the group identifiert for parameter {0}.
		/// </summary>
		public const string GroupDetailsUrlFormatString = "/groups/{0}.json";

		/// <summary>
		/// The URL format string for getting the people of a group. Needs the group identifiert for parameter {0}.
		/// </summary>
		public const string PersonsOfGroupUrlFormatString = "/groups/{0}/people.json";

		/// <summary>
		/// The URL format string for getting the details of a person. Needs the group identifiert for parameter {0} and de person identifier for parametter {1}.
		/// </summary>
		public const string PersonDetailsUrlFormatString = "/groups/{0}/people/{1}.json";

		#endregion
	}
}
