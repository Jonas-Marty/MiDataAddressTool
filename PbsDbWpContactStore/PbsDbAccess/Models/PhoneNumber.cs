namespace PbsDbAccess.Models
{
	/// <summary>
	/// Contains information about a phone number.
	/// </summary>
	public class PhoneNumber
	{
		/// <summary>
		/// Gets or sets the unique identifier.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the number.
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// Gets or sets the label.
		/// </summary>
		/// <example>
		/// Possible values are: Mobil, Arbeit, Vater, Mutter, Fax, Andere, Mobile and their translation to Italian an France.
		/// </example>
		public string Label { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this number is internal.
		/// If it is set to <c>true</c> everyone with read rights can see the number, 
		/// otherwise only persons in the same group can see the number.
		/// </summary>
		public bool IsPublic { get; set; }
	}
}