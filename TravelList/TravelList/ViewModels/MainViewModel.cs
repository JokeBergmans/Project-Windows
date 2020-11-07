using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelList.Services;
using TravelList.Views;

namespace TravelList.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

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
            //var json = await client.PostAsync(new Uri("htpp://localhost:5000/api/Account"))
            _navigationService.Navigate(typeof(LoginPage));
        }
    }
}
