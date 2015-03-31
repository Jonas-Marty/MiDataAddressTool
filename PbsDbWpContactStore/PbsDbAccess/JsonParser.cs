using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PbsDbAccess
{
	public static class JsonParser
	{
		public static LoggedinUserInformation ParseLoggedinUserInformation(string jsonString)
		{
			dynamic jsonData = JObject.Parse(jsonString);
			return new LoggedinUserInformation()
			{
				Id = jsonData.people[0].id,
				Token = jsonData.people[0].authentication_token,
				PrimaryGroupId = jsonData.people[0].links.primary_group,
				PrimaryGroupType = ((IEnumerable<dynamic>)jsonData.linked.groups)
					.First(group => group.id == jsonData.people[0].links.primary_group).group_type,
				LastName = jsonData.people[0].last_name,
				FirstName = jsonData.people[0].first_name,
				Nickname = jsonData.people[0].nickname,
			};
		}
	}
}