using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Trips
{
    public class TripDetailViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationService _navigationService;
        private readonly TripRepository _tripRepository;
        private readonly ItemRepository _itemRepository;
        public ObservableCollection<Item> items = new ObservableCollection<Item>();
        public readonly IEnumerable<int> numbers = Enumerable.Range(1, 10);
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

        public RelayCommand<int> RemoveItemCommand
        {
            get
            {
                return new RelayCommand<int>(RemoveItem);
            }
        }

        public RelayCommand AddTaskCommand
        {
            get
            {
                return new RelayCommand(AddTask);
            }
        }

        public RelayCommand<int> RemoveTaskCommand
        {
            get
            {
                return new RelayCommand<int>(RemoveTask);
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
            _navigationService.Navigate(typeof(MainPage), "Trips");
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
                Trip.Items.Add(new TripItem() { Amount = NewItem.Amount, Item = NewItem.Item, Packed = false });
                UpdateTrip();
            }
            NewItem.Clear();
        }

        public void RemoveItem(int id)
        {
            TripItem item = Trip.Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                Trip.Items.Remove(item);
                UpdateTrip();
            }
        }

        public void AddTask()
        {
            Trip.Tasks.Add(new Task() { Name = NewTask.Name, Completed = false });
            UpdateTrip();
            NewTask.Clear();
        }

        public void RemoveTask(int id)
        {
            Task task = Trip.Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                Trip.Tasks.Remove(task);
                UpdateTrip();
            }
        }

        public void SetupObserver()
        {
            Trip.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip();
            Trip.Tasks.ToList().ForEach(t => t.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip());
            Trip.Items.ToList().ForEach(i => i.PropertyChanged += (object sender, PropertyChangedEventArgs e) => UpdateTrip());
        }
        #endregion

    }
}
