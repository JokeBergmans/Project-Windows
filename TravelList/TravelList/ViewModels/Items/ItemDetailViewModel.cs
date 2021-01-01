using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        #endregion

        #region Properties
        public Item NewItem { get; set; }
        #endregion

        #region Constructors
        public ItemDetailViewModel()
        {
            _itemRepository = RepositoryService.ItemRepository;
            items = _itemRepository.Items;
            NewItem = new Item();
        }
        #endregion

        #region Methods
        public void AddItem()
        {
            _itemRepository.AddItem(new Item() { Name = NewItem.Name, Category = NewItem.Category });
            NewItem.Clear();
        }
        #endregion
    }
}
