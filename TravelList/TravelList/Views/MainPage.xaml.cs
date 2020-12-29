using System;
using System.Linq;
using TravelList.Services;
using TravelList.Views.Items;
using TravelList.Views.Itinerary;
using TravelList.Views.Settings;
using TravelList.Views.Trips;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TravelList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            nvMain.SelectedItem = nvMain.MenuItems.ElementAt(0);
        }

        public void NvMain_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
                mainContainer.Navigate(typeof(SettingsPage));
        }

        public void NvMain_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Tag)
            {
                case "nviTrips":
                    mainContainer.Navigate(typeof(TripsPage));
                    break;
                case "nviPastTrips":
                    mainContainer.Navigate(typeof(PastTripsPage));
                    break;
                case "nviItineraries":
                    mainContainer.Navigate(typeof(ItineraryPage));
                    break;
                case "nviItems":
                    mainContainer.Navigate(typeof(ItemPage));
                    break;
            }
        }

        public void NviLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            vm.LogoutCommand.Execute(null);
        }
    }
}
