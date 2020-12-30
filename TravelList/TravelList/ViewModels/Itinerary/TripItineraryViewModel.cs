using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        #endregion

        #region Constructors
        public TripItineraryViewModel()
        {
            _navigationService = new NavigationService();
            _tripRepository = RepositoryService.TripRepository;
        }
        #endregion

        #region Commands
        public RelayCommand BackCommand
        {
            get
            {
                return new RelayCommand(BackToOverview);
            }
        }

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
            IList<Activity> activities = Trip.Activities;
            Trip.Activities.Clear();
            activities.Add(NewActivity);
            activities.OrderBy(a => a.Start);
            activities.ToList().ForEach(a => Trip.Activities.Add(a));
            UpdateTrip();
            NewActivity = new Activity();
        }
        #endregion
    }
}
