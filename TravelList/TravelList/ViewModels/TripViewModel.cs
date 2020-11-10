using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TravelList.Models;
using TravelList.Models.Domain;
using TravelList.Services;
using TravelList.Utils;
using TravelList.Views;
using Windows.Networking.Connectivity;

namespace TravelList.ViewModels
{
    public class TripViewModel : ViewModelBase
    {
        private NavigationService _navigationService;
        public ObservableCollection<Trip> trips = new ObservableCollection<Trip>();
        public ObservableCollection<Trip> pastTrips = new ObservableCollection<Trip>();
        public DateTimeOffset Today = new DateTimeOffset((DateTime.Now).ToUniversalTime());
        public TripRequest Request { get; set; } = new TripRequest();

        public TripViewModel()
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


        private async void AddTrip()
        {
            Trip result = await ApiService.AddTrip(Request);
            trips.Add(result);

            _navigationService.Navigate(typeof(MainPage));
        }

        private async void GetTrips()
        {
            IList<Trip> tripsResult = await ApiService.GetTrips();
            tripsResult.ToList().ForEach(t => {
                if (t.Start.CompareTo(DateTime.Now) > 0)
                    trips.Add(t);
                else if (t.End.CompareTo(DateTime.Now) < 0)
                    pastTrips.Add(t);
                });

            /*            trips.Add(new Trip()
            {
                Name = "Test trip 1",
                Start = DateTime.Now.AddDays(20),
                End = DateTime.Now.AddDays(34),
                Tasks = new List<Task> { new Task(), new Task() { Completed = true} },
                Items = new List<Item>()
            });*/
        }
    }
}
