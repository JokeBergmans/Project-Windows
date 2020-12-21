using GalaSoft.MvvmLight.Command;
using System;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;
using System.Linq;
using System.ComponentModel;

namespace TravelList.ViewModels.Trips
{
    public class TripDetailViewModel
    {
        private readonly NavigationService _navigationService;
        private readonly TripRepository _tripRepository;
        private readonly ItemRepository _itemRepository;
        public DateTimeOffset Today = new DateTimeOffset(DateTime.Now.ToUniversalTime());

        public Trip Trip { get; set; }

        public TripDetailViewModel()
        {
            _navigationService = new NavigationService();
            _tripRepository = RepositoryService.TripRepository;
            _itemRepository = RepositoryService.ItemRepository;
        }

        public RelayCommand UpdateTripCommand
        {
            get
            {
                return new RelayCommand(UpdateTrip);
            }
        }

        public RelayCommand BackCommand
        {
            get
            {
                return new RelayCommand(BackToOverview);
            }
        }

        public void UpdateTrip()
        {
            _tripRepository.UpdateTrip(Trip);
        }

        public void BackToOverview()
        {
            _navigationService.Navigate(typeof(MainPage));
        }

        public void SetupObserver()
        {
            Trip.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip();
            Trip.Tasks.ToList().ForEach(t => t.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip());
            Trip.Items.ToList().ForEach(i => i.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip());
        }
    }
}
