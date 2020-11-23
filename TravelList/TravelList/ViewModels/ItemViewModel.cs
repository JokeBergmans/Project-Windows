using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelList.Models.Domain;
using TravelList.Services;
using TravelList.Views;

namespace TravelList.ViewModels
{
    public class ItemViewModel
    {

        private INavigationService _navigationService;
        public ObservableCollection<Item> items = new ObservableCollection<Item>();
        public ObservableCollection<string> categories = new ObservableCollection<string>();
        public Item NewItem { get; set; }

        public ItemViewModel()
        {
            _navigationService = new NavigationService();
            GetItems();
            NewItem = new Item();
        }

        private async void GetItems()
        {
            IList<Item> itemsResult = await ApiService.GetItems();
            itemsResult.ToList().ForEach(i => {
                items.Add(i);
                if (!categories.Contains(i.Category))
                    categories.Add(i.Category);
            });
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
