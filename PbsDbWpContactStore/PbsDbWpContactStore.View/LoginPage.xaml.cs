using Windows.UI.Xaml;
using PbsDbAccess;
using PbsDbWpContactStore.View.Common;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PbsDbWpContactStore.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            loginProgressBar.Visibility = Visibility.Visible;

            try
            {
                var access = await PbsDbWebAccess.CreateInstanceAsync(emailTextBox.Text, passwordBox.Password);
                await DataManager.SaveCredentialsAsync(new UserCredentials { Username = emailTextBox.Text, Password = passwordBox.Password });
                Frame.Navigate(typeof(DownloadPage), access);
                statusTextBlock.Visibility = Visibility.Collapsed;
            }
            catch (InvalidLoginInformationException ex)
            {
                statusTextBlock.Text = ex.Message;
                statusTextBlock.Visibility = Visibility.Visible;
            }
            finally
            {
                loginProgressBar.Visibility = Visibility.Collapsed;
            }
        }

        protected override void LoadState(object sender, LoadStateEventArgs e)
        {

        }

        protected override void SaveState(object sender, SaveStateEventArgs e)
        {
        }
    }
}
