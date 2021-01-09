using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Net.Http;
using TravelList.Models;
using TravelList.Repositories;
using TravelList.Services;
using TravelList.Utils;

namespace TravelList.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields
        private bool _loading = false;
        private readonly NavigationService _navigationService;
        private PreferenceRepository _preferenceRepository;
        #endregion

        #region Properties
        public Error Error { get; set; }
        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("Loading");
            }
        }
        public LoginRequest Request { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructors
        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            Request = new LoginRequest();
            Error = new Error();
        }
        #endregion

        #region Commands
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        #endregion

        #region Methods
        private async void Login()
        {
            try
            {
                Loading = true;
                string token = await ApiService.Login(Request);
                if (token == "")
                {
                    Error.Message = "Invalid login";
                    Loading = false;
                }
                else
                {
                    SessionManager.token = token;
                    Loading = false;
                    RepositoryService.Refresh();
                    _preferenceRepository = RepositoryService.PreferenceRepository;
                    _navigationService.Navigate(typeof(MainPage));
                }
            }
            catch (HttpRequestException)
            {
                Error.Message = "Unable to connect to API, please try again later";
                Loading = false;
            }

        }

        override public void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
