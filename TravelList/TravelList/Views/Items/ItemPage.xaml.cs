using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace TravelList.Views.Items
{
    public sealed partial class ItemPage : Page
    {
        public ItemPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(NewCategoryPage));

        }

        private void gv_ItemClick(object sender, ItemClickEventArgs e)
        {
            frame.Navigate(typeof(ItemDetailPage), (string)e.ClickedItem);
        }
    }
}
