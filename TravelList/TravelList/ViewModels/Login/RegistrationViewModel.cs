using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TravelList.Models;
using TravelList.Services;

namespace TravelList.ViewModels.Login
{
    public class RegistrationViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public RegistrationRequest Request { get; set; }

        public RelayCommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }


        public RegistrationViewModel()
        {
            Request = new RegistrationRequest();
            _navigationService = new NavigationService();
        }

        private async void Register()
        {
            if (await ApiService.Register(Request))
                _navigationService.Navigate(typeof(MainPage));
        }
    }
}
