using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TravelList.Models;
using TravelList.Models.Domain;
using TravelList.Services;

namespace TravelList.Repositories
{
    public class TripRepository
    {
        #region Properties
        public ObservableCollection<Trip> Trips { get; set; } = new ObservableCollection<Trip>();
        public ObservableCollection<Trip> PastTrips { get; set; } = new ObservableCollection<Trip>();
        #endregion

        #region Constructors
        public TripRepository()
        {
            GetTrips();
        }
        #endregion

        #region Methods
        public async void GetTrips()
        {
            Trips.Clear();
            PastTrips.Clear();
            List<Trip> trips = (List<Trip>)await ApiService.GetTrips();
            if (trips != null)
                trips.ForEach(t =>
                {
                    if (t.End.CompareTo(DateTime.Now) > 0 && !Trips.Contains(t))
                        Trips.Add(t);
                    else if (t.End.CompareTo(DateTime.Now) <= 0 && !PastTrips.Contains(t))
                        PastTrips.Add(t);
                });
        }

        public async void AddTrip(TripRequest request)
        {
            Trip trip = await ApiService.AddTrip(request);
            if (trip != null)
                GetTrips();
        }

        public async void UpdateTrip(Trip trip)
        {
            bool result = await ApiService.UpdateTrip(trip);
            if (result)
                GetTrips();
        }

        public async void RemoveTrip(Trip trip)
        {
            bool result = await ApiService.RemoveTrip(trip);
            if (result)
                GetTrips();
        }
        #endregion

    }
}
