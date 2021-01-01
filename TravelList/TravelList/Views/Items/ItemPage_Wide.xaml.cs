using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace TravelList.Views.Items
{

    public sealed partial class ItemPage_Wide : Page
    {
        public ItemPage_Wide()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            svFrame.Navigate(typeof(NewCategoryPage));

        }

        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            svFrame.Navigate(typeof(ItemDetailPage), (string)e.ClickedItem);
        }
    }
}
