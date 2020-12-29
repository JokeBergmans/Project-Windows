using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class PastTripsViewModel : ViewModelBase
    {
        private readonly TripRepository _tripRepository;
        public ObservableCollection<Trip> trips;

        public PastTripsViewModel()
        {
            _tripRepository = RepositoryService.TripRepository;
            trips = _tripRepository.PastTrips;
        }
    }
}
