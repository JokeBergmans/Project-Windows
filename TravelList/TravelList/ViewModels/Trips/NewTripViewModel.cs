using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using TravelList.Models;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class NewTripViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationService _navigationService;
        private readonly TripRepository _tripRepository;
        #endregion

        #region Properties
        public DateTimeOffset Today = new DateTimeOffset(DateTime.Now.ToUniversalTime());
        public TripRequest Request { get; set; } = new TripRequest();
        #endregion

        #region Constructors
        public NewTripViewModel()
        {
            _navigationService = new NavigationService();
            _tripRepository = RepositoryService.TripRepository;
        }
        #endregion

        #region Commands
        public RelayCommand AddTripCommand
        {
            get
            {
                return new RelayCommand(AddTrip);
            }
        }


        public RelayCommand BackCommand
        {
            get
            {
                return new RelayCommand(BackToOverview);
            }
        }
        #endregion

        #region Methods
        private void AddTrip()
        {
            _tripRepository.AddTrip(Request);
            _navigationService.Navigate(typeof(MainPage));
        }

        public void BackToOverview()
        {
            _navigationService.Navigate(typeof(MainPage));
        }
        #endregion
    }
}
