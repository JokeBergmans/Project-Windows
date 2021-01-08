using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace TravelList.Views.Trips
{
    public sealed partial class NewTripPage : Page
    {
        public NewTripPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (object sender, BackRequestedEventArgs e) => vm.BackToOverview();
        }


    }
}
