using System;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace HitzgiAddressTool
{
	static class Program
	{
		private static ILog Log;

		private const int LogLevel = 4;
		//0 -- prints only FATAL messages 
		//1 -- prints FATAL and ERROR messages 
		//2 -- prints FATAL , ERROR and WARN messages 
		//3 -- prints FATAL  , ERROR , WARN and INFO messages 
		//4 -- prints FATAL  , ERROR , WARN , INFO and DEBUG messages 


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			log4net.Util.LogLog.InternalDebugging = true;
			Log = LogManager.GetLogger(typeof (Program));

			AppDomain.CurrentDomain.UnhandledException +=
				(o, e) => Log.Fatal("Unhandled Exception in Current Domain", e.ExceptionObject as Exception);

			var fileAppender = new FileAppender
			{
				AppendToFile = true,
				File = FileUtil.FullLogFilePath,
				ImmediateFlush = true,
				LockingModel = new FileAppender.ExclusiveLock(),
				Name = "HATFileAppender",
				Threshold = new Level(LogLevel, "DEBUG"),
				Layout = new PatternLayout("%date [%thread] %-5level %logger [%property{NDC}] - %message%newline")
			};

			fileAppender.ActivateOptions();

			BasicConfigurator.Configure(fileAppender);

			

			Log.Info("Programm started and log4net configured");
			

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			InformationExchanger informationExchanger = new InformationExchanger();
			LoginForm loginForm = new LoginForm { InformationExchanger = informationExchanger };

			Log.Info("Show LoginForm");
			loginForm.ShowDialog();
			Log.Info("LoginForm closed");

			if (informationExchanger.PbsDbWebAccess == null) //then terminate programm because user closed form
			{
				Log.Info("Programm terminated after LoginForm has been closed");
				return;
			}

			MainForm mainForm = new MainForm { InformationExchanger = informationExchanger };

			Log.Info("Show MainForm");
			mainForm.ShowDialog();
			Log.Info("MainForm closed");

			Log.Info("Programm terminated after MainForme has been closed");
		}
	}
}
