namespace PbsDbAccess.Models
{
	public class Group
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public bool IsLayer { get; set; }

		public string ParentGroupId { get; set; }

		public string LayerGroupId { get; set; }

		public string[] ChildGroupIds { get; set; }
	}
}