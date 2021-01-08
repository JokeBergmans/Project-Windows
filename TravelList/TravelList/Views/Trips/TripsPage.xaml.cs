using System;
using System.Threading.Tasks;
using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views.Trips
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripsPage : Page
    {
        public TripsPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(NewTripPage));

        }

        private void gv_ItemClick(object sender, ItemClickEventArgs e)
        {
            frame.Navigate(typeof(TripDetailPage), (Trip)e.ClickedItem);
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
