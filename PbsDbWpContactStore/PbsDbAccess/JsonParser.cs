using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PbsDbAccess.JsonWrapperClasses;
using PbsDbAccess.Models;

namespace PbsDbAccess
{
	public static class JsonParser
	{
		public static LoggedinUserInformation ParseLoggedinUserInformation(string jsonString)
		{
			RootObjectJson root = DesierializeRootObject(jsonString);

			LoggedinUserInformation info = new LoggedinUserInformation
			{
				Id = root.People[0].Id,
				Email = root.People[0].Email,
				Token = root.People[0].AuthenticationToken,
				PrimaryGroupId = root.People[0].Links.PrimaryGroup,
				PrimaryGroupType = root.Linked.Groups.First(group => group.Id == root.People[0].Links.PrimaryGroup).GroupType,
				LastName = root.People[0].LastName,
				FirstName = root.People[0].FirstName,
				Nickname = root.People[0].Nickname
			};

			return info;
		}

		public static Group ParseGroup(string jsonString)
		{
			RootObjectJson root = DesierializeRootObject(jsonString);

			Group group = new Group
			{
				Id = root.Groups[0].Id,
				IsLayer = root.Groups[0].Layer,
				Name = root.Groups[0].Name,
				ParentGroupId = root.Groups[0].Links.ParentGroup,
				LayerGroupId = root.Groups[0].Links.LayerGroup,
				ChildGroupIds = root.Groups[0].Links.Children
			};

			return group;
		}

		public static IEnumerable<Person> ParsePeopleOfGroup(string jsonString)
		{
			RootObjectJson root = DesierializeRootObject(jsonString);

			return root.People.Select(person => new Person
			{
				Id = person.Id,
				Type = person.Type,
				Href = person.Href,
				FirstName = person.FirstName,
				LastName = person.LastName,
				Nickname = person.Nickname,
				CompanyName = person.CompanyName,
				Company = person.Company,
				Email = person.Email,
				AuthenticationToken = person.AuthenticationToken,
				Address = person.Address,
				ZipCode = person.ZipCode,
				Town = person.Town,
				Country = person.Country,
				Picture = person.Picture,
				Links = person.Links,
				Birthday = person.Birthday,
				Gender = person.Gender,
				AdditionalInformation = person.AdditionalInformation,
				PbsNumber = person.PbsNumber,
				JsNumber = person.JsNumber,
				SalutationValue = person.SalutationValue,
				CorrespondenceLanguage = person.CorrespondenceLanguage,
				GradeOfSchool = person.GradeOfSchool,
				HasBrotherAndSisters = person.HasBrotherAndSisters,
				EntryDate = person.EntryDate,
				LeavingDate = person.LeavingDate,
				CreatedAt = person.CreatedAt,
				UpdatedAt = person.UpdatedAt
			});
		}


		private static RootObjectJson DesierializeRootObject(string jsonString)
		{
			var serializerSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};

			return JsonSerializer.Create(serializerSettings).Deserialize<RootObjectJson>(new JsonTextReader(new StringReader(jsonString)));
		}
	}
}