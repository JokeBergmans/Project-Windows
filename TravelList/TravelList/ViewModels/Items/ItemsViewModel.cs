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
        #region Fields
        public ObservableCollection<string> categories = new ObservableCollection<string>();
        private readonly ItemRepository _itemRepository;
        #endregion

        #region Constructors
        public ItemsViewModel()
        {
            _itemRepository = RepositoryService.ItemRepository;
            GetCategories();
        }
        #endregion

        #region Methods
        private void GetCategories()
        {
            categories.Clear();
            _itemRepository.Items.ToList().Select(i => i.Category).Distinct().ToList().ForEach(c => categories.Add(c));

        }
        #endregion



    }
}
