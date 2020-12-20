using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelList.Models.Domain;
using TravelList.Services;

namespace TravelList.Repositories
{
    public class ItemRepository
    {
        public ObservableCollection<Item> Items { get; set; }

        public ItemRepository()
        {
            GetItems();
        }

        public async void GetItems()
        {
            Items = new ObservableCollection<Item>();
            List<Item> items = (List<Item>)await ApiService.GetItems();
            items.ForEach(t => Items.Add(t));

        }

        public async void AddItem(Item request)
        {
            Item item = await ApiService.AddItem(request);
            if (item != null)
                GetItems();
        }

/*        public async void UpdateItem(Item item)
        {
            bool result = await ApiService.UpdateItem(item);
            if (result)
                GetItems();
        }*/
    }
}
