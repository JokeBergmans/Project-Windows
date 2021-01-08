using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;


namespace TravelList.Views.Itinerary
{
    public sealed partial class ItineraryPage : Page
    {
        public ItineraryPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void gv_ItemClick(object sender, ItemClickEventArgs e)
        {
            frame.Navigate(typeof(TripItineraryPage), (Trip)e.ClickedItem);
        }
    }
}
