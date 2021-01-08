using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelList.Models.Domain;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace TravelList.Views.Trips
{

    public sealed partial class PastTripItineraryPage : Page
    {
        public PastTripItineraryPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (object sender, BackRequestedEventArgs e) => vm.BackToOverview();
        }
        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            vm.Trip = (Trip)args.Parameter;
        }

        private void Details_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PastTripDetailPage), vm.Trip);
        }
    }
}
