using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TravelList.Models;
using TravelList.Models.Domain;
using Windows.Networking.Connectivity;

namespace TravelList.ViewModels
{
    public class TripViewModel : ViewModelBase
    {
        public ObservableCollection<Trip> trips;

        public TripViewModel()
        {
            trips = new ObservableCollection<Trip>();
            trips.Add(new Trip()
            {
                Name = "Test trip 1",
                Start = DateTime.Now.AddDays(20),
                Tasks = new List<Task>(),
                Items = new List<Item>()
            });
        }
    }
}
