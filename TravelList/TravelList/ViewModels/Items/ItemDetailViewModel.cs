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
        public ObservableCollection<Item> items = new ObservableCollection<Item>();
        public Item NewItem { get; set; }
        private ItemRepository _itemRepository;

        public ItemDetailViewModel()
        {
            _itemRepository = RepositoryService.ItemRepository;
            NewItem = new Item();
        }
        public async Task<IList<Item>> FilterItems(string category)
        {
            IList<Item> itemsResult = await ApiService.GetItems();
            return itemsResult.Where(i => i.Category == category).ToList();
        }

        public async void AddItem()
        {
            await ApiService.AddItem(NewItem);
            items.Add(NewItem);
            NewItem = new Item();
        }
    }
}
