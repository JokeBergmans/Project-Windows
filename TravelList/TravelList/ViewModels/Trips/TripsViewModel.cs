using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TravelList.Models;
using TravelList.Models.Domain;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class TripsViewModel : ViewModelBase
    {
        private NavigationService _navigationService;
        public ObservableCollection<Trip> trips = new ObservableCollection<Trip>();
        public ObservableCollection<Trip> pastTrips = new ObservableCollection<Trip>();
        public DateTimeOffset Today = new DateTimeOffset(DateTime.Now.ToUniversalTime());
        public TripRequest Request { get; set; } = new TripRequest();
        public Trip SelectedTrip { get; set; } = new Trip();

        public TripsViewModel()
        {
            _navigationService = new NavigationService();

            GetTrips();
        }

        public RelayCommand AddTripCommand
        {
            get
            {
                return new RelayCommand(AddTrip);
            }
        }

        public RelayCommand UpdateTripCommand
        {
            get
            {
                return new RelayCommand(UpdateTrip);
            }
        }


        private async void AddTrip()
        {
            Trip result = await ApiService.AddTrip(Request);
            trips.Add(result);

            _navigationService.Navigate(typeof(MainPage));
        }

        private async void UpdateTrip()
        {
            System.Diagnostics.Debug.WriteLine("Changed");
        }

        private async void GetTrips()
        {
            IList<Trip> tripsResult = await ApiService.GetTrips();
            tripsResult.ToList().ForEach(t =>
            {
                if (t.Start.CompareTo(DateTime.Now) > 0)
                    trips.Add(t);
                else if (t.End.CompareTo(DateTime.Now) < 0)
                    pastTrips.Add(t);
            });
        }
    }
}
