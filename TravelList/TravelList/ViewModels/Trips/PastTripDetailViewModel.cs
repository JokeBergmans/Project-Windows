using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class PastTripDetailViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationService _navigationService;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        #endregion

        #region Constructors
        public PastTripDetailViewModel()
        {
            _navigationService = new NavigationService();
        }
        #endregion

        #region Commands
        public RelayCommand BackCommand
        {
            get
            {
                return new RelayCommand(BackToOverview);
            }
        }
        #endregion

        #region Methods
        public void BackToOverview()
        {
            _navigationService.Navigate(typeof(MainPage), "PastTrips");
        }
        #endregion
    }
}
