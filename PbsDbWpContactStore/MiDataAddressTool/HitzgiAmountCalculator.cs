using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using PbsDbAccess.Models;

namespace MiDataAddressTool
{
	public class HitzgiAmountCalculator
	{
		private Dictionary<Group, IEnumerable<Person>> _groupPersonAssociantion;

		public HitzgiAmountCalculator(Dictionary<Group, IEnumerable<Person>> groupPersonAssociantion)
		{
			_groupPersonAssociantion = groupPersonAssociantion;
		}

		public int CalculateTotalAmountOfHitzgisNeeded(List<Group> selectedGroups)
		{
			var distinctedSet = GetPersonsDistinct(selectedGroups).DistinctBy(person => new { person.LastName, person.Address });
			return distinctedSet.Count();
		}

		public int CalculateTotalAmountOfDistinctHitzgiRecievers(List<Group> selectedGroups)
		{
			var distinctedSet = GetPersonsDistinct(selectedGroups);
			return distinctedSet.Count();
		}

		public IEnumerable<Person> GetPersonsDistinct(List<Group> selectedGroups)
		{
			List<string> groupIds = selectedGroups.Select(group => group.Id).ToList();
			var selectedGroupPersonAsscociation = _groupPersonAssociantion.Where(kvp => groupIds.Contains(kvp.Key.Id)).ToList();

			var allPeople = selectedGroupPersonAsscociation.SelectMany(asscociation => asscociation.Value);
			return allPeople.DistinctBy(person => person.Id);
		}
	}
}