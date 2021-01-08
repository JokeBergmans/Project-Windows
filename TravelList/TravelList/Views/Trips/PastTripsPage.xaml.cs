using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace TravelList.Views.Trips
{
    public sealed partial class PastTripsPage : Page
    {
        public PastTripsPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
        private void gv_ItemClick(object sender, ItemClickEventArgs e)
        {
            frame.Navigate(typeof(PastTripDetailPage), (Trip)e.ClickedItem);
        }

    }
}
