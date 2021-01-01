using Windows.UI.Core;
using Windows.UI.Xaml.Controls;


namespace TravelList.Views.Items
{
    public sealed partial class NewCategoryPage : Page
    {
        public NewCategoryPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (object sender, BackRequestedEventArgs e) => vm.BackToOverview();
        }
    }
}
