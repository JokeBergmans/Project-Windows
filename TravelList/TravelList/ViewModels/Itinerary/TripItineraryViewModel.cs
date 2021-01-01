using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Itinerary
{
    public class TripItineraryViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationService _navigationService;
        private readonly TripRepository _tripRepository;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        public Activity NewActivity { get; set; } = new Activity();
        public TimeSpan TimeSpan { get; set; } = new TimeSpan();
        #endregion

        #region Constructors
        public TripItineraryViewModel()
        {
            _navigationService = new NavigationService();
            _tripRepository = RepositoryService.TripRepository;
        }
        #endregion

        #region Commands
        public RelayCommand AddCommand
        {
            get
            {
                return new RelayCommand(AddActivity);
            }
        }
        #endregion

        #region Methods
        public void UpdateTrip()
        {
            _tripRepository.UpdateTrip(Trip);
        }

        public void BackToOverview()
        {
            _navigationService.Navigate(typeof(MainPage), "Itineraries");
        }

        public void AddActivity()
        {
            NewActivity.Start = NewActivity.Start.Date + TimeSpan;
            Trip.Activities.Add(new Activity() { Name = NewActivity.Name, Description = NewActivity.Description, Location = NewActivity.Location, Start = NewActivity.Start });
            UpdateTrip();
            NewActivity.Clear();
            SetActivityMinDate(Trip.Start);
            TimeSpan.Subtract(TimeSpan);
            OrderActivities();
        }

        public void OrderActivities()
        {
            IList<Activity> activities = new List<Activity>(Trip.Activities);
            Trip.Activities.Clear();
            activities.OrderBy(a => a.Start).ToList().ForEach(a => Trip.Activities.Add(a));
        }

        public void SetActivityMinDate(DateTime min)
        {
            NewActivity.Start = min;
        }
        #endregion
    }
}
