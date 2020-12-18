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

        public ObservableCollection<Trip> Trips { get; set; }
        public ObservableCollection<Trip> PastTrips { get; set; }

        public TripRepository()
        {
            GetTrips();
        }

        public async void GetTrips()
        {
            Trips = new ObservableCollection<Trip>();
            PastTrips = new ObservableCollection<Trip>();
            List<Trip> trips = (List<Trip>) await ApiService.GetTrips();
            trips.ForEach(t => {
                if (t.Start.CompareTo(DateTime.Now) > 0)
                    Trips.Add(t);
                else if (t.End.CompareTo(DateTime.Now) <= 0)
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
