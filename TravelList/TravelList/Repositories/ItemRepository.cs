using System.Collections.Generic;
using System.Collections.ObjectModel;
using TravelList.Models.Domain;
using TravelList.Services;

namespace TravelList.Repositories
{
    public class ItemRepository
    {
        #region Properties
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        #endregion

        #region Constructors
        public ItemRepository()
        {
            GetItems();
        }
        #endregion

        #region Methods
        public async void GetItems()
        {
            Items.Clear();
            List<Item> items = (List<Item>)await ApiService.GetItems();
            items.ForEach(i =>
            {
                Items.Add(i);
                if (!Categories.Contains(i.Category))
                    Categories.Add(i.Category);
            });

        }

        public async void AddItem(Item request)
        {
            Item item = await ApiService.AddItem(request);
            if (item != null)
                GetItems();
        }
        #endregion

    }

}
