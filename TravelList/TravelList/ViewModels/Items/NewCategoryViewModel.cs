using GalaSoft.MvvmLight.Command;
using TravelList.Repositories;
using TravelList.Services;

namespace TravelList.ViewModels.Items
{
    public class NewCategoryViewModel
    {
        #region Fields
        private readonly ItemRepository _itemRepository;
        private readonly NavigationService _navigationService;
        #endregion

        #region Properties
        public string Category { get; set; } = "";
        #endregion

        #region Constructors
        public NewCategoryViewModel()
        {
            _itemRepository = RepositoryService.ItemRepository;
            _navigationService = new NavigationService();
        }
        #endregion

        #region Commands
        public RelayCommand AddCategoryCommand
        {
            get
            {
                return new RelayCommand(AddCategory);
            }
        }
        #endregion

        #region Methods
        public void AddCategory()
        {
            _itemRepository.Categories.Add(Category);
            Category = "";
            _navigationService.Navigate(typeof(MainPage), "Items");

        }

        public void BackToOverview()
        {
            _navigationService.Navigate(typeof(MainPage), "Items");
        }
        #endregion
    }
}
