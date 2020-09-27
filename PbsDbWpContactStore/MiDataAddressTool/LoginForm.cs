using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;
using PbsDbAccess;

namespace MiDataAddressTool
{
    public partial class LoginForm : Form
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(LoginForm));

        public LoginForm()
        {
            InitializeComponent();
            SetVisibility();
        }

        public InformationExchanger InformationExchanger { get; set; }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if (TokenRadioButton.Checked && (string.IsNullOrWhiteSpace(GroupIdTextBox.Text) || string.IsNullOrWhiteSpace(TokenTextBox.Text)))
            {
                return;
            }
            else if (UserRadioButton.Checked && (string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Text)))
            {
                return;
            }

            SaveCredentials();

            EnterLoadingMode();

            try
            {
                if (TokenRadioButton.Checked)
                {
                    InformationExchanger.PbsDbWebAccess = await PbsDbWebAccess.CreateInstanceAsyncServiceUser(TokenTextBox.Text, GroupIdTextBox.Text);
                }
                else
                {
                    InformationExchanger.PbsDbWebAccess = await PbsDbWebAccess.CreateInstanceAsyncUser(EmailTextBox.Text, PasswordTextBox.Text);
                }
                ErrorLabel.Text = "Login erfolgreich :)";
                _log.Info("Successfully logged in");
                Thread.Sleep(500);
                Close();
            }
            catch (InvalidLoginInformationException ex)
            {
                ErrorLabel.Text = ex.Message;
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
            EmailTextBox.Enabled = !isLoading;
            PasswordTextBox.Enabled = !isLoading;
            LoginButton.Enabled = !isLoading;
            loadingPictureBox.Visible = isLoading;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadCredentials();
        }

        private void SaveCredentials()
        {
            LoginCredentials credentials = new LoginCredentials { Email = EmailTextBox.Text, Password = PasswordTextBox.Text, Token = TokenTextBox.Text, PrimaryGroupId = GroupIdTextBox.Text };

            try
            {
                FileUtil.SaveLoginCredentials(credentials);
                _log.Info("Credentials successfully saved");
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
                EmailTextBox.Text = loadedCredentials.Email;
                PasswordTextBox.Text = loadedCredentials.Password;
                TokenTextBox.Text = loadedCredentials.Token;
                GroupIdTextBox.Text = loadedCredentials.PrimaryGroupId;
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

        private void TokenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibility();
        }

        private void UserRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibility();
        }

        private void SetVisibility()
        {
            TokenLabel.Visible = TokenRadioButton.Checked;
            TokenTextBox.Visible = TokenRadioButton.Checked;
            GroupIdLabel.Visible = TokenRadioButton.Checked;
            GroupIdTextBox.Visible = TokenRadioButton.Checked;
            PasswordLabel.Visible = !TokenRadioButton.Checked;
            PasswordTextBox.Visible = !TokenRadioButton.Checked;
            EmailTextBox.Visible = !TokenRadioButton.Checked;
            EmailLabel.Visible = !TokenRadioButton.Checked;
        }
    }
}
