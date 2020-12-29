using System.Collections.ObjectModel;
using TravelList.Models;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Itinerary
{
    public class ItineraryViewModel
    {
        private readonly TripRepository _tripRepository;
        public ObservableCollection<Trip> trips;

        public ItineraryViewModel()
        {
            _tripRepository = RepositoryService.TripRepository;
            trips = _tripRepository.Trips;
        }
    }
}
