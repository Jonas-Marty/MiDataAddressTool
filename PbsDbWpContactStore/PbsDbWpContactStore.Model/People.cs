using System.Collections.Generic;

namespace PbsDbWpContactStore.Model
{
	public class People : List<Person>
	{
		public People()
		{
			this.Add(new Person
			{
				Address = "Schöntalweg 4",
				FirstName = "Jonas",
				Name = "Marty",
				Place = "Oberarth",
				ScoutName = "Wiwo",
				ZipCode = "6414"
			});

			this.Add(new Person
			{
				Address = "Chapfweidweg 2",
				FirstName = "Roman",
				Name = "Culatti",
				Place = "Steinerberg",
				ScoutName = "Robinson",
				ZipCode = "6416"
			});

			this.Add(new Person
			{
				Address = "Obere Roosmatt 7",
				FirstName = "Rebekka",
				Name = "Bachmann",
				Place = "Zug",
				ScoutName = "Assente",
				ZipCode = "6300"
			});
		}
	}
}
