using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TravelList.Models;
using TravelList.Services;

namespace TravelList.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {

        private INavigationService _navigationService;
        public string ErrorMessage { get; set; } = "";
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


        private async void Login()
        {
            if (await ApiService.Login(Request))
                _navigationService.Navigate(typeof(MainPage));
            else
                ErrorMessage = "Invalid login";
                
        }

    }
}
