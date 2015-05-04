using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using PbsDbAccess;

namespace HitzgiAddressTool
{
	public partial class LoginForm : Form
	{
		private const string SettingsFoldername = "HitzgiAddressTool";
		private const string CredentialsFileName = "Credentials.dat";

		private string CompleteCredentialsFilePath
		{
			get
			{
				string pathToMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				return Path.Combine(pathToMyDocuments, SettingsFoldername, CredentialsFileName);
			}
		}

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
				Thread.Sleep(500);
				Close();
			}
			catch (InvalidLoginInformationException ex)
			{
				errorLabel.Text = ex.Message;
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

			CreateSettingsFolderIfNotExits();

			using (FileStream fileStream = new FileStream(CompleteCredentialsFilePath, FileMode.Create))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(LoginCredentials));
				serializer.Serialize(fileStream, credentials);
			}
		}

		private void LoadCredentials()
		{
			if (!File.Exists(CompleteCredentialsFilePath))
			{
				return;
			}

			try
			{
				LoginCredentials loadedCredentials;
				using (FileStream fileStream = new FileStream(CompleteCredentialsFilePath, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof (LoginCredentials));
					loadedCredentials = (LoginCredentials) serializer.Deserialize(fileStream);
				}
				emailTextBox.Text = loadedCredentials.Email;
				passwortTextBox.Text = loadedCredentials.Password;
			}
			catch (InvalidOperationException) //The only exception XmlSerializer.Deserialize will throw
			{
				//do nothing, just skip loading
			}
			catch (IOException) //thrown by new FileStream if somethings wrong there
			{
				//also do nothing and skip loading the credentials
			}
		}

		private void CreateSettingsFolderIfNotExits()
		{
			string directoryPath = Path.GetDirectoryName(CompleteCredentialsFilePath);
			Debug.Assert(directoryPath != null, "Should never be null");
			Directory.CreateDirectory(directoryPath);
		}
	}
}
