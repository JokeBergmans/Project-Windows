using System.Collections.ObjectModel;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Items
{
    public class ItemsViewModel
    {
        #region Fields
        public ObservableCollection<string> categories = new ObservableCollection<string>();
        private readonly ItemRepository _itemRepository;
        #endregion

        #region Constructors
        public ItemsViewModel()
        {
            _itemRepository = RepositoryService.ItemRepository;
            categories = _itemRepository.Categories;
        }
        #endregion

    }
}
