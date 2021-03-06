﻿using System.ComponentModel;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TravelList.Views.Login
{
    public sealed partial class LoginPage : Page
    {

        public LoginPage()
        {
            InitializeComponent();
            vm.PropertyChanged += (object sender, PropertyChangedEventArgs e) => SetLoading(vm.Loading);
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

        private void SetLoading(bool isLoading)
        {
            if (isLoading)
            {
                loading.Visibility = Visibility.Visible;
                loading.IsActive = true;
                loginBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                loading.Visibility = Visibility.Collapsed;
                loading.IsActive = false;
                loginBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
