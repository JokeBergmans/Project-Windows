using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelList.Models.Domain;
using TravelList.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ItemDetailPage : Page
    {
        public ObservableCollection<Item> items = new ObservableCollection<Item>();
        public string Category { get; set; }

        public ItemDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Category = (string)e.Parameter;
            GetItems();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            vm.NewItem.Category = Category;
            items.Add(vm.NewItem);
            vm.AddItem();
        }

        private async void GetItems()
        {
            IList<Item> itemsResult = await vm.FilterItems(Category);
            itemsResult.ToList().ForEach(i => items.Add(i));
        }
    }
}
