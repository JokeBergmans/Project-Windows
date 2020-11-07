using System;
using System.ComponentModel;
using System.Net.Http;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TravelList.Models;
using TravelList.Services;

namespace TravelList.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private INavigationService _navigationService;
        public LoginRequest Request { get; set; }

        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            Request = new LoginRequest();
        }


        private void Login()
        {
            HttpClient client = new HttpClient();
            //var json = await client.PostAsync(new Uri("htpp://localhost:5000/api/Account"))
            System.Diagnostics.Debug.WriteLine("Email=" + Request.Email);
            _navigationService.Navigate(typeof(MainPage));
        }

    }
}
