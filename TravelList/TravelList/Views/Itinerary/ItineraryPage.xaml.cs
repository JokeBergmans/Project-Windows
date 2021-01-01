using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views.Itinerary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
