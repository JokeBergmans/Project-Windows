using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Net.Http;
using TravelList.Models;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Login
{
    public class RegistrationViewModel : ViewModelBase
    {
        #region Fields
        private bool _loading = false;
        private PreferenceRepository _preferenceRepository;
        private readonly NavigationService _navigationService;
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
        public RegistrationRequest Request { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructors
        public RegistrationViewModel()
        {
            Request = new RegistrationRequest();
            _navigationService = new NavigationService();
            Error = new Error();
        }
        #endregion

        #region Commands
        public RelayCommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }
        #endregion

        #region Methods
        private async void Register()
        {
            try
            {
                Loading = true;
                string token = await ApiService.Register(Request);
                if (token == "")
                {
                    Error.Message = "Invalid registration";
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
