using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TravelList.Views.Login
{
    public sealed partial class LoginPage : Page
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPage));
        }

        private void OnKeyDownHandler(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                vm.LoginCommand.Execute(null);
            }
        }
    }
}
