using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PbsDbAccess.Models;

namespace PbsDbAccessTestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.BufferHeight = Int16.MaxValue - 1;

			LoggedinUserInformation userInfo = null;
			var task1 = Task.Run(async () => userInfo = await PbsDbAccess.PbsDbAccess.RecieveUserInformationAsync("wiwo@outlook.com", "J268210pfadi"));


			try
			{
				task1.Wait();
				Console.WriteLine(userInfo.Token);
			}
			catch (Exception)
			{
				Console.WriteLine(task1.Exception.InnerException.Message);

			}

			Console.ReadKey();

			var access = new PbsDbAccess.PbsDbAccess(userInfo);

			IEnumerable<Group> groups = null;
			var task2 = Task.Run(async () => groups = await access.RecieveAllGroupsFromLayerGroupAsync());

			try
			{
				task2.Wait();
				foreach (Group group in groups)
				{
					Console.WriteLine("{0}:\t{1}", group.Id, group.Name);
					IEnumerable<Person> persons = null;
					var task3 = Task.Run(async () => persons = await access.RecievePersonsOfGroupAsync(group.Id));
					try
					{
						task3.Wait();
						foreach (Person person in persons)
						{
							Console.WriteLine("\t{0} {1} {2}", person.Nickname, person.FirstName, person.LastName);
						}
					}
					catch (Exception)
					{
						Console.WriteLine(task3.Exception.InnerException.Message);
						throw;
					}
				}
			}
			catch (Exception)
			{
				Console.WriteLine(task2.Exception.InnerException.Message);
			}

			Console.ReadKey();
		}
	}
}
