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
        public ObservableCollection<Item> items;
        public Item NewItem { get; set; }
        private ItemRepository _itemRepository;

        public ItemDetailViewModel()
        {
            _itemRepository = RepositoryService.ItemRepository;
            items = _itemRepository.Items;
            NewItem = new Item();
        }

        public void AddItem()
        {
            _itemRepository.AddItem(NewItem);
            NewItem = new Item();
        }
    }
}
