using GalaSoft.MvvmLight.Command;
using System;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class TripDetailViewModel
    {
        private NavigationService _navigationService;
        private TripRepository _tripRepository;
        public DateTimeOffset Today = new DateTimeOffset(DateTime.Now.ToUniversalTime());

        public Trip Trip { get; set; }

        public TripDetailViewModel()
        {
            _navigationService = new NavigationService();
            _tripRepository = RepositoryService.TripRepository;
        }

        public RelayCommand UpdateTripCommand
        {
            get
            {
                return new RelayCommand(UpdateTrip);
            }
        }

        public void UpdateTrip()
        {
            _tripRepository.UpdateTrip(Trip);
        }
    }
}
