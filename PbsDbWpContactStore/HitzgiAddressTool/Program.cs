using System;
using System.Windows.Forms;

namespace HitzgiAddressTool
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			InformationExchanger informationExchanger = new InformationExchanger();
			LoginForm loginForm = new LoginForm { InformationExchanger = informationExchanger };

			loginForm.ShowDialog();

			if (informationExchanger.PbsDbWebAccess == null) //then terminate programm because user closed form
			{
				return;
			}

			MainForm mainForm = new MainForm { InformationExchanger = informationExchanger };

			mainForm.ShowDialog();
		}
	}
}
