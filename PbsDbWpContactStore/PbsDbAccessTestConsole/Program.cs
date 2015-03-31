using System;
using System.Threading.Tasks;
using PbsDbAccess;

namespace PbsDbAccessTestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			LoggedinUserInformation userInfo = null;
			var task = Task.Run(async () => userInfo = await PbsDbAccess.PbsDbAccess.RecieveUserInformationAsync("wiwo@outlook.com", "J268210pfadi"));


			try
			{
				task.Wait();
				Console.WriteLine(userInfo.Token);
			}
			catch (Exception)
			{
				Console.WriteLine(task.Exception.InnerException.Message);

			}

			Console.ReadKey();
		}
	}
}
