using TravelList.Models;
using TravelList.Models.Domain;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views.Trips
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PastTripsPage : Page
    {
        public PastTripsPage()
        {
            InitializeComponent();
        }
        private void gv_ItemClick(object sender, ItemClickEventArgs e)
        {
            frame.Navigate(typeof(PastTripDetailPage), (Trip)e.ClickedItem);
        }

    }
}
