using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace TravelList.Views.Trips
{
    public sealed partial class TripsPage_Wide : Page
    {
        public TripsPage_Wide()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            svFrame.Navigate(typeof(NewTripPage));

        }

        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            svFrame.Navigate(typeof(TripDetailPage), (Trip)e.ClickedItem);
        }
    }
}
