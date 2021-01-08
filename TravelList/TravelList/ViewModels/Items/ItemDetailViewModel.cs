using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Items
{
    public class ItemDetailViewModel
    {
        #region Fields
        public ObservableCollection<Item> items;
        private readonly ItemRepository _itemRepository;
        private readonly NavigationService _navigationService;
        #endregion

        #region Properties
        public Item NewItem { get; set; }
        public string Category { get; set; }
        #endregion

        #region Constructors
        public ItemDetailViewModel()
        {
            _navigationService = new NavigationService();
            _itemRepository = RepositoryService.ItemRepository;
            items = _itemRepository.Items;
            NewItem = new Item();
        }
        #endregion

        #region Commands
        public RelayCommand AddCommand
        {
            get
            {
                return new RelayCommand(AddItem);
            }
        }

        public RelayCommand<int> RemoveCommand
        {
            get
            {
                return new RelayCommand<int>(RemoveItem);
            }
        }
        #endregion

        #region Methods
        public void AddItem()
        {
            NewItem.Category = Category;
            _itemRepository.AddItem(new Item() { Name = NewItem.Name, Category = NewItem.Category });
            NewItem.Clear();
        }

        public void RemoveItem(int id)
        {
            Item[] copiedItems = new Item[items.Count];
            items.CopyTo(copiedItems, 0);
            Item item = copiedItems.ToList().FirstOrDefault(t => t.Id == id);
            if (item != null)
                _itemRepository.RemoveItem(item);
        }

        public void BackToOverview()
        {
            _navigationService.Navigate(typeof(MainPage), "Items");
        }
        #endregion
    }
}
