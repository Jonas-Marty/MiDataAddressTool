using System;

namespace PbsDbAccess.Models
{
	/// <summary>
	/// Contains information of a role which the user has.
	/// </summary>
	public class Role
	{
		/// <summary>
		/// Gets or sets the identifier of the role. This is identifier is unique for every entry.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the type of the role. This is a string property which contains a word describing the role. i.g.: "Rover".
		/// </summary>
		/// <remarks>
		/// All roles are listed here https://www.dropbox.com/sh/gycyx2r0ookv9du/ZW4_DZLNlb in the document "Funktionen_xx_xxx...".
		/// Alternatively they are listed in the github repository in the README.rdoc in https://github.com/hitobito/hitobito_pbs.
		/// </remarks>
		public string RoleType { get; set; }

		/// <summary>
		/// Gets or sets the date when this role has been created.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the date when this role has been updated.
		/// </summary>
		/// <value>
		/// The updated at.
		/// </value>
		public DateTime UpdatedAt { get; set; }

		/// <summary>
		/// Gets or sets the date when this role has been deleted. If the is not deleted the value is null.
		/// </summary>
		public DateTime? DeletedAt { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the group where this role aplies.
		/// </summary>
		public string Group { get; set; }

		/// <summary>
		/// Gets or sets the identifier of layer group of the group where this role aplies.
		/// If the <see cref="Group"/> is a layer group, then this propertey equals to <see cref="Group"/>.
		/// </summary>
		public string LayerGroup { get; set; }
	}
}