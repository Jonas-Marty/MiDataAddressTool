using System;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using OfficeOpenXml;

namespace MiDataAddressTool;
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

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        AppDomain.CurrentDomain.UnhandledException +=
            (o, e) => Log.Fatal("Unhandled Exception in Current Domain", e.ExceptionObject as Exception);

        var layout = new PatternLayout("%date Thread:[%2thread] %-5level %logger - %message%newline")
        {
				
            Header = "[Log Start]\n",
            Footer = "[Log End]\n" + new string('-', 60) + "\n"
        };

        var fileAppender = new FileAppender
        {
            AppendToFile = true,
            File = FileUtil.FullLogFilePath,
            ImmediateFlush = true,
            LockingModel = new FileAppender.ExclusiveLock(),
            Name = "HATFileAppender",
            Threshold = new Level(LogLevel, "DEBUG"),
            Layout = layout				
        };

        fileAppender.ActivateOptions();

        BasicConfigurator.Configure(fileAppender);

        Log.Info("Program started and log4net configured");
        Log.Info($"ProductName: {Application.ProductName}");
        Log.Info($"ProductVersion: {Application.ProductVersion}");
        Log.Info($"ExecutablePath: {Application.ExecutablePath}");
        Log.Info($"StartUpPath: {Application.StartupPath}");
        Log.Info($"OS: {Environment.OSVersion}");
        Log.Info($"UserName: {Environment.UserName}");
        Log.Info($"MachineName: {Environment.MachineName}");
        Log.Info($"ProcessorCount: {Environment.ProcessorCount}");
        Log.Info($"CurrentCulture: {Application.CurrentCulture}");
        Log.Info($"CurrentInputLanguage: {Application.CurrentCulture}");
        Log.Info($"ClrVersion: {Environment.Version}");


        Application.EnableVisualStyles();
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.SetCompatibleTextRenderingDefault(false);

        InformationExchanger informationExchanger = new InformationExchanger();
        LoginForm loginForm = new LoginForm { InformationExchanger = informationExchanger };

        Log.Info("Show LoginForm");
        loginForm.ShowDialog();
        Log.Info("LoginForm closed");

        if (informationExchanger.MiDataAccess == null) //then terminate program because user closed form
        {
            Log.Info("Program terminated after LoginForm has been closed");
            return;
        }

        MainForm mainForm = new MainForm { InformationExchanger = informationExchanger };

        Log.Info("Show MainForm");
        mainForm.ShowDialog();
        Log.Info("MainForm closed");

        Log.Info("Program terminated after MainForm has been closed");
    }
}