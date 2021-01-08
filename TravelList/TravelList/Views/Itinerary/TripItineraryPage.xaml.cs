using System;
using System.Threading.Tasks;
using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace TravelList.Views.Itinerary
{
    public sealed partial class TripItineraryPage : Page
    {
        public TripItineraryPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (object sender, BackRequestedEventArgs e) => vm.BackToOverview();
        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            vm.Trip = (Trip)args.Parameter;
            vm.OrderActivities();
            vm.SetActivityMinDate(vm.Trip.Start);
        }

        private async void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await ShowDeleteDialog();
            if (result == ContentDialogResult.Primary)
            {
                object id = ((Button)sender).Tag;
                vm.RemoveCommand.Execute((int)id);
            }

        }

        private async Task<ContentDialogResult> ShowDeleteDialog()
        {
            ContentDialog deleteActivityDialog = new ContentDialog
            {
                Title = "Delete activity permanently?",
                Content = "If you delete this activity, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteActivityDialog.ShowAsync();
            return result;
        }

    }
}
