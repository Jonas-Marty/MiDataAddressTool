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

		/// <summary>
		/// Initializes the <see cref="JsonSerializer"/> property
		/// </summary>
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
				Email = root.People[0].Email,
				UserToken = root.People[0].AuthenticationToken,
				PrimaryGroupId = root.People[0].Links.PrimaryGroup,
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
				IsLayerGroup = root.Groups[0].IsLayerGroup,
				Name = root.Groups[0].Name,
				ParentGroupId = root.Groups[0].Grouplinks.ParentGroup,
				LayerGroupId = root.Groups[0].Grouplinks.LayerGroup,
				ChildGroupIds = root.Groups[0].Grouplinks.Children
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
				Href = person.Href,
				FirstName = person.FirstName,
				LastName = person.LastName,
				Nickname = person.Nickname,
				CompanyName = person.CompanyName,
				IsCompany = person.IsCompany,
				Email = person.Email,
				AuthenticationToken = person.AuthenticationToken,
				Address = person.Address,
				ZipCode = person.ZipCode,
				Town = person.Town,
				Country = person.Country,
				Picture = person.Picture,
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
				UpdatedAt = person.UpdatedAt,
				Updater = person.Links.Updater,
				Creator = person.Links.Creator,
				PrimaryGroup = person.Links.PrimaryGroup,
				PhoneNumbers = ParsePhoneNumbers(root, person),
				AdditionalEmails = ParseAdditionalEmails(root, person),
				Roles = ParseRoles(root, person)
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

		private static IEnumerable<Role> ParseRoles(RootObjectJson root, PersonJson person)
		{
			//No ned to check if user has roles, he must have at least one to be returned.
			return root.Linked.Roles
				.Where(role => person.Links.Roles.Any(roleId => roleId == role.Id))
				.Select(role => new Role
				{
					Id = role.Id,
					CreatedAt = role.CreatedAt,
					DeletedAt = role.DeletedAt,
					RoleType = role.RoleType,
					UpdatedAt = role.UpdatedAt,
					Group = role.Links.Group,
					LayerGroup = role.Links.LayerGroup
				});
		}

		private static IEnumerable<AdditionalEmail> ParseAdditionalEmails(RootObjectJson root, PersonJson person)
		{
			if (person.Links.AdditionalEmails != null)
			{
				return root.Linked.AdditionalEmail
						.Where(additionalEmail => person.Links.AdditionalEmails.Any(additionalEmailId => additionalEmailId == additionalEmail.Id))
						.Select(additionalEmail => new AdditionalEmail
						{
							Id = additionalEmail.Id,
							Email = additionalEmail.Email,
							Label = additionalEmail.Label,
							IsPublic = additionalEmail.IsPublic,
							Mailings = additionalEmail.Mailings
						});
			}
			return Enumerable.Empty<AdditionalEmail>();
		}

		private static IEnumerable<PhoneNumber> ParsePhoneNumbers(RootObjectJson root, PersonJson person)
		{
			if (person.Links.PhoneNumbers != null)
			{
				return root.Linked.PhoneNumbers
						.Where(phoneNumber => person.Links.PhoneNumbers.Any(phoneNumberId => phoneNumberId == phoneNumber.Id))
						.Select(phoneNumber => new PhoneNumber
						{
							Id = phoneNumber.Id,
							Number = phoneNumber.Number,
							Label = phoneNumber.Label,
							IsPublic = phoneNumber.IsPublic
						});
			}
			return Enumerable.Empty<PhoneNumber>();
		}
	}
}