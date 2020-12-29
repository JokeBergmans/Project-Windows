using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using TravelList.Models;
using TravelList.Services;

namespace TravelList.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private bool _loading = false;
        private NavigationService _navigationService;
        public Error Error { get; set; }
        public bool Loading { 
            get { return _loading; } 
            set 
            { 
                _loading = value;
                RaisePropertyChanged("Loading");
            } 
        }
        public LoginRequest Request { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            Request = new LoginRequest();
            Error = new Error();
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }


        private async void Login()
        {
            Loading = true;
            string token = await ApiService.Login(Request);
            if (token == "")
            {
                Error.Message = "Invalid login";
                System.Diagnostics.Debug.WriteLine("Error: " + Error.Message);
                Loading = false;
            }
            else
            {
                SessionManager.token = token;
                Loading = false;
                _navigationService.Navigate(typeof(MainPage));
            }
        }

        override public void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
