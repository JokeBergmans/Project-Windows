using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelList.ViewModels;
using TravelList.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
                    mainContainer.Navigate(typeof(TripPage));
                    break;
                case "nviPastTrips":
                    mainContainer.Navigate(typeof(PastTripPage));
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
