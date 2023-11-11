using System.Collections.Generic;
using System.Linq;
using MiDataAccess.Models;

namespace MiDataAddressTool;

public class HitzgiAmountCalculator
{
    private readonly IReadOnlyDictionary<Group, IEnumerable<Person>> _groupPersonAssociation;

    public HitzgiAmountCalculator(IReadOnlyDictionary<Group, IEnumerable<Person>> groupPersonAssociation)
    {
        _groupPersonAssociation = groupPersonAssociation;
    }

    public int CalculateTotalAmountOfHitzgisNeeded(List<Group> selectedGroups)
    {
        var distinctedSet = GetPersonsDistinct(selectedGroups).DistinctBy(person => new { person.LastName, person.Address });
        return distinctedSet.Count();
    }

    public int CalculateTotalAmountOfDistinctHitzgiReceivers(List<Group> selectedGroups)
    {
        var distinctedSet = GetPersonsDistinct(selectedGroups);
        return distinctedSet.Count();
    }

    public IEnumerable<Person> GetPersonsDistinct(List<Group> selectedGroups)
    {
        List<string> groupIds = selectedGroups.Select(group => group.Id).ToList();
        var selectedGroupPersonAsscociation = _groupPersonAssociation.Where(kvp => groupIds.Contains(kvp.Key.Id)).ToList();

        var allPeople = selectedGroupPersonAsscociation.SelectMany(asscociation => asscociation.Value);
        return allPeople.DistinctBy(person => person.Id);
    }
}