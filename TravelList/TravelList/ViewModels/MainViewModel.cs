using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TravelList.Services;
using TravelList.Views.Login;

namespace TravelList.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private NavigationService _navigationService;
        #endregion

        #region Constructors
        public MainViewModel()
        {
            _navigationService = new NavigationService();
        }
        #endregion

        #region Commands
        public RelayCommand LogoutCommand
        {
            get
            {
                return new RelayCommand(Logout);
            }
        }
        #endregion

        #region Methods
        private void Logout()
        {
            SessionManager.token = "";
            _navigationService.Navigate(typeof(LoginPage));
        }
        #endregion
    }
}
