using System.ComponentModel;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TravelList.Views.Login
{
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            vm.PropertyChanged += (object sender, PropertyChangedEventArgs e) => SetLoading(vm.Loading);
        }

        private void LoginButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {

            Frame.Navigate(typeof(LoginPage));
        }

        private void OnKeyDownHandler(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                vm.RegisterCommand.Execute(null);
            }
        }

        private void SetLoading(bool isLoading)
        {
            if (isLoading)
            {
                loading.Visibility = Visibility.Visible;
                loading.IsActive = true;
                registerBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                loading.Visibility = Visibility.Collapsed;
                loading.IsActive = false;
                registerBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
