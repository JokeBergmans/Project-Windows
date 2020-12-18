using GalaSoft.MvvmLight.Command;
using System;
using TravelList.Models;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class NewTripViewModel
    {
        private NavigationService _navigationService;
        private TripRepository _tripRepository;
        public DateTimeOffset Today = new DateTimeOffset(DateTime.Now.ToUniversalTime());
        public TripRequest Request { get; set; } = new TripRequest();


        public NewTripViewModel()
        {
            _navigationService = new NavigationService();
            _tripRepository = RepositoryService.TripRepository;
        }

        public RelayCommand AddTripCommand
        {
            get
            {
                return new RelayCommand(AddTrip);
            }
        }

        private void AddTrip()
        {
            _tripRepository.AddTrip(Request);
            _navigationService.Navigate(typeof(MainPage));
        }
    }
}
