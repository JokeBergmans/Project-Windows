using System.Collections.Specialized;
using System.Linq;
using Windows.UI.Core;
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
    }
}
