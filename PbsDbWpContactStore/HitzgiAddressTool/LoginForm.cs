using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using log4net;
using Newtonsoft.Json;
using PbsDbAccess;

namespace HitzgiAddressTool
{
	public partial class LoginForm : Form
	{
		private readonly ILog _log = LogManager.GetLogger(typeof(LoginForm));

		public LoginForm()
		{
			InitializeComponent();
		}

		public InformationExchanger InformationExchanger { get; set; }

		private async void loginButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(passwortTextBox.Text))
			{
				return;
			}

			SaveCredentials();

			EnterLoadingMode();

			try
			{
				//TODO Catch  [System.Net.Http.HttpRequestException]	{"An error occurred while sending the request."}	System.Net.Http.HttpRequestException
				// -		InnerException	{"The remote name could not be resolved: 'db.scout.ch'"}	System.Exception {System.Net.WebException}
				/*   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at PbsDbAccess.PbsDbWebAccess.<CreateInstanceAsync>d__9.MoveNext() in h:\Programmieren\GitHub\HitobitoPBS_WPContactStore\PbsDbWpContactStore\PbsDbAccess\PbsDbWebAccess.cs:line 102
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at HitzgiAddressTool.LoginForm.<loginButton_Click>d__0.MoveNext() in h:\Programmieren\GitHub\HitobitoPBS_WPContactStore\PbsDbWpContactStore\HitzgiAddressTool\LoginForm.cs:line 46
				 */
				//Consider catching in PbsDvWebAccess and throwing a custom Exception, together with loggin the
				//original exception.
				//In the UI show something like: "Die Verbindung zur Datenbank konnte nicht hergestellt werden,
				//Prüfe ob db.scout.ch über de Browser erreichbar ist, falls ja, dann wende dich an den Ersteller
				//dieses Programmes und sende ihm das logfile welches du <<hier>> findest.
				InformationExchanger.PbsDbWebAccess = await PbsDbWebAccess.CreateInstanceAsync(emailTextBox.Text, passwortTextBox.Text);
				errorLabel.Text = "Login erfolgreich :)";
				_log.Info("Successfully logged in");
				Thread.Sleep(500);
				Close();
			}
			catch (InvalidLoginInformationException ex)
			{
				errorLabel.Text = ex.Message;
				_log.Info("Wrong login credentials provided");
			}

			LeaveLoadingMode();
		}

		private void LeaveLoadingMode()
		{
			SetMode(false);
		}

		private void EnterLoadingMode()
		{
			SetMode(true);
		}

		private void SetMode(bool isLoading)
		{
			emailTextBox.Enabled = !isLoading;
			passwortTextBox.Enabled = !isLoading;
			loginButton.Enabled = !isLoading;
			loadingPictureBox.Visible = isLoading;
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			LoadCredentials();
		}

		private void SaveCredentials()
		{
			LoginCredentials credentials = new LoginCredentials { Email = emailTextBox.Text, Password = passwortTextBox.Text };

			try
			{
				FileUtil.SaveLoginCredentials(credentials);
				_log.Info("Credentials successfuly saved");
			}
			catch (IOException ex)
			{
				_log.Warn("Credentials could not be saved", ex);
			}
		}

		private void LoadCredentials()
		{
			try
			{
				LoginCredentials loadedCredentials = FileUtil.LoadLoginCredentials();
				emailTextBox.Text = loadedCredentials.Email;
				passwortTextBox.Text = loadedCredentials.Password;
				_log.Info("Credentials successfully loaded");
			}
			catch (JsonReaderException ex) //Something was wrong with the saved JsonText
			{
				_log.Warn("Credentials could not be loaded", ex);
				//do nothing, just skip loading
			}
			catch (IOException ex) //thrown by new FileStream(...) if somethings wrong there
			{
				_log.Warn("Credentials could not be loaded", ex);
				//also do nothing and skip loading the credentials
			}
		}
	}
}
