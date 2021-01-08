using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class TripsViewModel : ViewModelBase
    {
        #region Fields
        private readonly TripRepository _tripRepository;
        public ObservableCollection<Trip> trips;
        #endregion

        #region Constructors
        public TripsViewModel()
        {
            _tripRepository = RepositoryService.TripRepository;
            trips = _tripRepository.Trips;
        }
        #endregion

        #region Commands
        public RelayCommand<int> RemoveCommand
        {
            get
            {
                return new RelayCommand<int>(RemoveTrip);
            }
        }
        #endregion

        #region Methods
        public void RemoveTrip(int id)
        {
            Trip[] copiedTrips = new Trip[trips.Count];
            trips.CopyTo(copiedTrips, 0);
            Trip trip = copiedTrips.ToList().FirstOrDefault(t => t.Id == id);
            if (trip != null)
                _tripRepository.RemoveTrip(trip);

        }
        #endregion
    }
}
