using Newtonsoft.Json;

namespace PbsDbAccess.JsonWrapperClasses
{
	/// <summary>
	/// Contains a list of People an a Collection of linked objects
	/// (phone numbers, groups, roles and additional emailadresses).
	/// </summary>
	public class RootObject
	{
		/// <summary>
		/// Gets or sets a an array of Persons.
		/// </summary>
		[JsonProperty("people")]
		public Person[] People { get; set; }

		/// <summary>
		/// Gets or sets the linked information 
		/// </summary>
		[JsonProperty("linked")]
		public Linked Linked { get; set; }
	}
}