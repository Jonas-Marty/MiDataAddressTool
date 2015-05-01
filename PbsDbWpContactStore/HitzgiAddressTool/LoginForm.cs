using System;
using System.Windows.Forms;
using PbsDbAccess;

namespace HitzgiAddressTool
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private async void loginButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(passwortTextBox.Text))
			{
				return;
			}


			EnterLoadingMode();

			try
			{
				await PbsDbWebAccess.CreateInstanceAsync(emailTextBox.Text, passwortTextBox.Text);
				errorLabel.Text = "Logged in :)";
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
	}
}
