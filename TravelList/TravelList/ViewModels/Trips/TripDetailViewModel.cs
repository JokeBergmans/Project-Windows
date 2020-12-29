using GalaSoft.MvvmLight.Command;
using System;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;
using System.Linq;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace TravelList.ViewModels.Trips
{
    public class TripDetailViewModel
    {
        #region Fields
        private readonly NavigationService _navigationService;
        private readonly TripRepository _tripRepository;
        private readonly ItemRepository _itemRepository;
        public ObservableCollection<Item> items = new ObservableCollection<Item>();
        #endregion

        #region Properties
        public DateTimeOffset Today { get; set; } = new DateTimeOffset(DateTime.Now.ToUniversalTime());
        public Trip Trip { get; set; }
        public TripItem NewItem { get; set; } = new TripItem();
        public Task NewTask { get; set; } = new Task();
        #endregion

        #region Constructors
        public TripDetailViewModel()
        {
            _navigationService = new NavigationService();
            _tripRepository = RepositoryService.TripRepository;
            _itemRepository = RepositoryService.ItemRepository;
            items = _itemRepository.Items;
        }
        #endregion

        #region Commands
        public RelayCommand AddItemCommand
        {
            get
            {
                return new RelayCommand(AddItem);
            }
        }

        public RelayCommand AddTaskCommand
        {
            get
            {
                return new RelayCommand(AddTask);
            }
        }

        public RelayCommand BackCommand
        {
            get
            {
                return new RelayCommand(BackToOverview);
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
            _navigationService.Navigate(typeof(MainPage));
        }

        public void AddItem()
        {
            TripItem existing = Trip.Items.FirstOrDefault(i => i.Item.Id == NewItem.Item.Id);
            if (existing != null)
            {
                existing.Amount += NewItem.Amount;
                existing.Packed = false;
                existing.RaisePropertyChanged("Amount");
            }
            else
            {
                Trip.Items.Add(NewItem);
                UpdateTrip();
            }
            NewItem = new TripItem();
        }

        public void AddTask()
        {
            Trip.Tasks.Add(NewTask);
            NewTask = new Task();
        }

        public void SetupObserver()
        {
            Trip.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip();
            Trip.Tasks.ToList().ForEach(t => t.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip());
            Trip.Items.ToList().ForEach(i => i.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip());
            Trip.Tasks.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => UpdateTrip();
            //Trip.Items.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => UpdateTrip();
        }
        #endregion

    }
}
