using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;


namespace TravelList.Views.Itinerary
{
    public sealed partial class ItineraryPage_Wide : Page
    {
        public ItineraryPage_Wide()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            svFrame.Navigate(typeof(TripItineraryPage), (Trip)e.ClickedItem);
        }
    }
}
