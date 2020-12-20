using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TravelList.Models;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class TripsViewModel : ViewModelBase
    {
        private readonly TripRepository _tripRepository;
        public ObservableCollection<Trip> trips;

        public TripsViewModel()
        {
            _tripRepository = RepositoryService.TripRepository;
            trips = _tripRepository.Trips;
        }
    }
}
