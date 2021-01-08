using System;
using System.Threading.Tasks;
using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace TravelList.Views.Trips
{
    public sealed partial class TripsPage_Wide : Page
    {
        public TripsPage_Wide()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            svFrame.Navigate(typeof(NewTripPage));

        }

        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            svFrame.Navigate(typeof(TripDetailPage), (Trip)e.ClickedItem);
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
            ContentDialog deleteTripDialog = new ContentDialog
            {
                Title = "Delete trip permanently?",
                Content = "If you delete this trip, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteTripDialog.ShowAsync();
            return result;
        }
    }
}
