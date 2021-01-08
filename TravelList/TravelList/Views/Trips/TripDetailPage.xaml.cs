using System.ComponentModel;
using System.Linq;
using TravelList.Models.Domain;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TravelList.Views.Trips
{
    public sealed partial class TripDetailPage : Page
    {
        public TripDetailPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (object sender, BackRequestedEventArgs e) => vm.BackToOverview();

        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            vm.Trip = (Trip)args.Parameter;
            SetupCVS();
            vm.SetupObserver();
            vm.Trip.Items.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => SetupCVS();
            vm.Trip.Items.ToList().ForEach(i => i.PropertyChanged += (object sender, PropertyChangedEventArgs e) => SetupCVS());
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

        private void Remove_Item_Button_Click(object sender, RoutedEventArgs e)
        {
            object id = ((Button)sender).Tag;
            vm.RemoveItemCommand.Execute((int)id);
        }

        private void Remove_Task_Button_Click(object sender, RoutedEventArgs e)
        {
            object id = ((Button)sender).Tag;
            vm.RemoveTaskCommand.Execute((int)id);
        }
    }
}
