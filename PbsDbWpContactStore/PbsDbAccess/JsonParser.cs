using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PbsDbAccess.JsonWrapperClasses;
using PbsDbAccess.Models;

namespace PbsDbAccess
{
	/// <summary>
	/// A class to parse the recieved json string into typed objects.
	/// </summary>
	internal static class JsonParser
	{
		private static readonly JsonSerializer JsonSerializer;

		static JsonParser()
		{
			var serializerSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};

			JsonSerializer = JsonSerializer.Create(serializerSettings);
		}

		/// <summary>
		/// Parses the LoggedInUserInformation out of the json string.
		/// </summary>
		/// <param name="jsonString">The json string to parse.</param>
		/// <returns>The <see cref="LoggedinUserInformation"/>.</returns>
		internal static LoggedinUserInformation ParseLoggedinUserInformation(string jsonString)
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

		/// <summary>
		/// Parses a <see cref="Group"/> out of the recieved json string.
		/// </summary>
		/// <param name="jsonString">The recieved json string.</param>
		/// <returns>The parsed <see cref="Group"/>.</returns>
		internal static Group ParseGroup(string jsonString)
		{
			RootObjectJson root = DesierializeRootObject(jsonString);

			Group group = new Group
			{
				Id = root.Groups[0].Id,
				IsLayerGroup = root.Groups[0].Layer,
				Name = root.Groups[0].Name,
				ParentGroupId = root.Groups[0].Links.ParentGroup,
				LayerGroupId = root.Groups[0].Links.LayerGroup,
				ChildGroupIds = root.Groups[0].Links.Children
			};

			return group;
		}

		/// <summary>
		/// Parses the the people of a <see cref="Group"/> out of the recieved json string.
		/// </summary>
		/// <param name="jsonString">The recieved json string.</param>
		/// <returns>The parsed <see cref="Person"/>s.</returns>
		internal static IEnumerable<Person> ParsePeopleOfGroup(string jsonString)
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

		/// <summary>
		/// Deserializes the fiven json string into the a class scheme. This scheme must be further mapped
		/// into custom classes.
		/// </summary>
		/// <param name="jsonString">The json string to parse</param>
		/// <returns>The deserialized <see cref="RootObjectJson"/>.</returns>
		internal static RootObjectJson DesierializeRootObject(string jsonString)
		{
			return JsonSerializer.Deserialize<RootObjectJson>(new JsonTextReader(new StringReader(jsonString)));
		}
	}
}