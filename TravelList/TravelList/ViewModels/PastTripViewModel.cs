using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TravelList.Models;
using TravelList.Models.Domain;

namespace TravelList.ViewModels
{
    public class PastTripViewModel : ViewModelBase
    {
        public ObservableCollection<Trip> trips;

        public PastTripViewModel()
        {
            trips = new ObservableCollection<Trip>();
            trips.Add(new Trip()
            {
                Name = "Past trip 1",
                Start = DateTime.Now.AddDays(-50),
                End = DateTime.Now.AddDays(-30),
                Tasks = new List<Task> { new Task(), new Task() { Completed = true } },
                Items = new List<Item>()
            });
        }
    }
}
