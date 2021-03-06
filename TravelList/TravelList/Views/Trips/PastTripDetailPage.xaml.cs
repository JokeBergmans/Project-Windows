﻿using System.Linq;
using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TravelList.Views.Trips
{
    public sealed partial class PastTripDetailPage : Page
    {
        public PastTripDetailPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (object sender, BackRequestedEventArgs e) => vm.BackToOverview();
        }
        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            vm.Trip = (Trip)args.Parameter;
            SetupCVS();
        }

        private void SetupCVS()
        {
            var result =
                from i in vm.Trip.Items
                group i by i.Item.Category into g
                orderby g.Key
                select g;
            groupCVS.Source = result;
            lvItems.SelectedItem = null;
        }

        private void Activities_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PastTripItineraryPage), vm.Trip);
        }
    }


}
