using System.Collections.ObjectModel;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Itinerary
{
    public class ItineraryViewModel
    {
        #region Fields
        private readonly TripRepository _tripRepository;
        public ObservableCollection<Trip> trips;
        #endregion

        #region Constructors
        public ItineraryViewModel()
        {
            _tripRepository = RepositoryService.TripRepository;
            trips = _tripRepository.Trips;
        }
        #endregion

    }
}
