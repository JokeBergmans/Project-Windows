using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TravelList.Services;
using TravelList.Views.Login;

namespace TravelList.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationService _navigationService;

        public RelayCommand LogoutCommand
        {
            get
            {
                return new RelayCommand(Logout);
            }
        }

        public MainViewModel()
        {
            _navigationService = new NavigationService();
        }

        private void Logout()
        {
            SessionManager.token = "";
            _navigationService.Navigate(typeof(LoginPage));
        }
    }
}
