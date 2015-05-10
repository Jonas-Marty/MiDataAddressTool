using System.Diagnostics;

namespace PbsDbAccess.Models
{
	[DebuggerDisplay("{Id} - {Name},nq")]
	public class Group
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public bool IsLayerGroup { get; set; }

		public string ParentGroupId { get; set; }

		public string LayerGroupId { get; set; }

		public string[] ChildGroupIds { get; set; }
	}
}