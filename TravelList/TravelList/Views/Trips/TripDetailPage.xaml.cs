using System.Linq;
using TravelList.Models;
using TravelList.Models.Domain;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views.Trips
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripDetailPage : Page
    {
        public TripDetailPage()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vm.Trip = (Trip)e.Parameter;
            SetupCVS();
        }

        private void SetupCVS()
        {
            var result =
                from i in vm.Trip.Items
                group i by i.Category into g
                orderby g.Key
                select g;
            groupCVS.Source = result;
            lvItems.SelectedItem = null;
        }
    }
}
