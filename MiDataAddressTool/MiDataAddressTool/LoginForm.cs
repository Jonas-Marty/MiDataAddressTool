using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using log4net;
using MiDataAccess;
using Newtonsoft.Json;

namespace MiDataAddressTool;

public partial class LoginForm : Form
{
    private readonly ILog _log = LogManager.GetLogger(typeof(LoginForm));

    public LoginForm()
    {
        InitializeComponent();
    }

    public InformationExchanger InformationExchanger { get; set; }

    private async void LoginButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TokenTextBox.Text) || !int.TryParse(PrimaryGroupIdTextBox.Text, out _))
        {
            return;
        }

        EnterLoadingMode();

        SaveCredentials();

        try
        {
            InformationExchanger.MiDataAccess = await MiDataAccess.MiDataAccess.CreateInstanceAsync(TokenTextBox.Text, PrimaryGroupIdTextBox.Text);

            ErrorLabel.Text = "Login erfolgreich 🥳";
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
        LoginButton.Enabled = !isLoading;
        loadingPictureBox.Visible = isLoading;
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        LoadCredentials();
    }

    private void SaveCredentials()
    {
        LoginInformation information = new LoginInformation
        {
            Token = TokenTextBox.Text,
            PrimaryGroupId = int.Parse(PrimaryGroupIdTextBox.Text)
        };

        try
        {
            FileUtil.SaveLoginCredentials(information);
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
            LoginInformation loginInformation = FileUtil.LoadLoginInformation();
            TokenTextBox.Text = loginInformation.Token;
            PrimaryGroupIdTextBox.Text = loginInformation.PrimaryGroupId.ToString();
            _log.Info("LoginInformation successfully loaded");
        }
        catch (Exception ex) when (ex is JsonReaderException or IOException)
        {
            _log.Warn("LoginInformation could not be loaded", ex);
            //do nothing, just skip loading
        }
    }
}