using System.Linq;
using TravelList.Views.Items;
using TravelList.Views.Itinerary;
using TravelList.Views.Settings;
using TravelList.Views.Trips;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


namespace TravelList
{
    public sealed partial class MainPage : Page
    {
        public double PrevWidth { get; set; }

        public MainPage()
        {
            InitializeComponent();
            nvMain.SelectedItem = nvMain.MenuItems.ElementAt(0);
            Window.Current.SizeChanged += Window_SizeChanged;
            PrevWidth = ((Frame)Window.Current.Content).ActualWidth;
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            double actualWidth = ((Frame)Window.Current.Content).ActualWidth;
            if ((PrevWidth >= 1000 && actualWidth < 1000) || (PrevWidth < 1000 && actualWidth >= 1000))
            {
                object item = nvMain.SelectedItem;
                nvMain.SelectedItem = null;
                nvMain.SelectedItem = item;
                PrevWidth = actualWidth;
            }

        }

        public void NvMain_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
                mainContainer.Navigate(typeof(SettingsPage));
        }

        public void NvMain_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;
            if (item != null)
            {

                switch (item.Tag)
                {
                    case "nviTrips":
                        if (IsWindowSizeSmall())
                            mainContainer.Navigate(typeof(TripsPage));
                        else
                            mainContainer.Navigate(typeof(TripsPage_Wide));
                        break;
                    case "nviPastTrips":
                        if (IsWindowSizeSmall())
                            mainContainer.Navigate(typeof(PastTripsPage));
                        else
                            mainContainer.Navigate(typeof(PastTripsPage_Wide));
                        break;
                    case "nviItineraries":
                        if (IsWindowSizeSmall())
                            mainContainer.Navigate(typeof(ItineraryPage));
                        else
                            mainContainer.Navigate(typeof(ItineraryPage_Wide));
                        break;
                    case "nviItems":
                        if (IsWindowSizeSmall())
                            mainContainer.Navigate(typeof(ItemPage));
                        else
                            mainContainer.Navigate(typeof(ItemPage_Wide));
                        break;
                }
            }
        }

        public void NviLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            vm.LogoutCommand.Execute(null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            switch ((string)args.Parameter)
            {
                case "Trips":
                    nvMain.SelectedItem = nviTrips;
                    break;
                case "PastTrips":
                    nvMain.SelectedItem = nviPastTrips;
                    break;
                case "Itineraries":
                    nvMain.SelectedItem = nviItineraries;
                    break;
                case "Items":
                    nvMain.SelectedItem = nviItems;
                    break;
            }
        }

        public bool IsWindowSizeSmall()
        {
            double width = ((Frame)Window.Current.Content).ActualWidth;

            if (width < 1000)
                return true;
            else
                return false;
        }
    }
}
