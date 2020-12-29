using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Net.Http;
using TravelList.Models;
using TravelList.Services;

namespace TravelList.ViewModels.Login
{
    public class RegistrationViewModel : ViewModelBase
    {
        private bool _loading = false;
        private NavigationService _navigationService;
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
        public event PropertyChangedEventHandler PropertyChanged;

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
            try { 
                Loading = true;
                string token = await ApiService.Register(Request);
                if (token == "")
                {
                    //Error.Message = "Invalid login";
                    System.Diagnostics.Debug.WriteLine("failed");
                    Loading = false;
                }
                else
                {
                    SessionManager.token = token;
                    _navigationService.Navigate(typeof(MainPage));
                    Loading = false;
                }
            }
            catch (HttpRequestException)
            {
                //Error.Message = "Unable to connect to API, please try again later";
                Loading = false;
            }
        }

        override public void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
