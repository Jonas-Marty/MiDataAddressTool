using System;
using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	/// <summary>
	/// Contains a list of People an a Collection of linked objects
	/// (phone numbers, groups, roles and additional emailadresses).
	/// </summary>
	public class RootObjectJson
	{
		/// <summary>
		/// Gets or sets a an array of Persons.
		/// </summary>
		[JsonProperty("people")]
		public PersonJson[] People { get; set; }

		/// <summary>
		/// Gets or sets the linked information 
		/// </summary>
		[JsonProperty("linked")]
		public LinkedJson Linked { get; set; }

		[JsonProperty("groups")]
		public GroupJson[] Groups { get; set; }
	}
}