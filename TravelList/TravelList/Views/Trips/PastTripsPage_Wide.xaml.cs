using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace TravelList.Views.Trips
{
    public sealed partial class PastTripsPage_Wide : Page
    {
        public PastTripsPage_Wide()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            svFrame.Navigate(typeof(PastTripDetailPage), (Trip)e.ClickedItem);
        }
    }
}
