using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using TravelList.Models.Domain;
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
        public string Category { get; set; }

        public ItemDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Category = (string)e.Parameter;
            GetItems();
            vm.items.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs args) => GetItems();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            vm.NewItem.Category = Category;
            vm.AddItem();
        }

        private void GetItems()
        {
            var result =
                from i in vm.items
                where i.Category == Category
                orderby i.Name
                select i;
            cvs.Source = result;

        }
    }
}
