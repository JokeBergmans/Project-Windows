using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Items
{
    public class ItemsViewModel
    {

        public ObservableCollection<string> categories = new ObservableCollection<string>();
        private ItemRepository _itemRepository;

        public ItemsViewModel()
        {
            _itemRepository = RepositoryService.ItemRepository;
            GetCategories();
        }

        private void GetCategories()
        {
            _itemRepository.Items.ToList().ForEach(i =>
            {
                if (!categories.Contains(i.Category))
                    categories.Add(i.Category);
            });
        }



    }
}
