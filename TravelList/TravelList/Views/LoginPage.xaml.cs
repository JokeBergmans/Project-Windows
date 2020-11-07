using System;
using System.ServiceModel.Channels;
using TravelList.Services;
using TravelList.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TravelList.Views
{
    public sealed partial class LoginPage : Page
    {
        private LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ErrorMessage.Text = "";
        }
    }
}
