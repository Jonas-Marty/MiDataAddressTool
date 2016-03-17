using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using PbsDbAccess.Models;
using PbsDbWpContactStore.View.Common;
using PbsDbWpContactStore.View.Model;

namespace PbsDbWpContactStore.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactPage
    {
        private const string PersonKey = "Person";

        public ContactPage()
        {
            InitializeComponent();
        }

        protected override void LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.NavigationParameter != null)
            {
                DefaultViewModel[PersonKey] = e.NavigationParameter;
            }
            else if (e.PageState.ContainsKey(PersonKey))
            {
                DefaultViewModel[PersonKey] = e.PageState[PersonKey];
            }
            else
            {
                Frame.Navigate(typeof (MainPage));
            }
        }

        protected override void SaveState(object sender, SaveStateEventArgs e)
        {
            if (DefaultViewModel[PersonKey] != null)
            {
                e.PageState[PersonKey] = DefaultViewModel[PersonKey];
            }
        }
        
        private void PhoneNumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            string number = (string)((Button)e.OriginalSource).Content;
            var person = (PersonViewModel)DefaultViewModel[PersonKey];

            PhoneNumber phoneNumber = person.PhoneNumbers.First(n => n.Number == number);

            string displayName = $"{person.DisplayName} ({phoneNumber.Label})";

            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(number, displayName);
        }
    }
}
