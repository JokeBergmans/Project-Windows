using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views.Items
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ItemDetailPage : Page
    {

        public ItemDetailPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (object sender, BackRequestedEventArgs e) => vm.BackToOverview();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vm.Category = (string)e.Parameter;
            GetItems();
            vm.items.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs args) => GetItems();
        }

        private void GetItems()
        {
            var result =
                from i in vm.items
                where i.Category == vm.Category
                orderby i.Name
                select i;
            cvs.Source = result;

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
            ContentDialog deleteItemDialog = new ContentDialog
            {
                Title = "Delete item permanently?",
                Content = "If you delete this item, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            return result;
        }
    }
}
