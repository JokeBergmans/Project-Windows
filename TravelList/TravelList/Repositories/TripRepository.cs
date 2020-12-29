using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelList.Models;
using TravelList.Models.Domain;
using TravelList.Services;

namespace TravelList.Repositories
{
    public class TripRepository
    {

        public ObservableCollection<Trip> Trips { get; set; } = new ObservableCollection<Trip>();
        public ObservableCollection<Trip> PastTrips { get; set; } = new ObservableCollection<Trip>();

        public TripRepository()
        {
            GetTrips();
        }

        public async void GetTrips()
        {
            Trips.Clear();
            PastTrips.Clear();
            List<Trip> trips = (List<Trip>)await ApiService.GetTrips();
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


    }
}
