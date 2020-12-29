using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using System.ComponentModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            vm.PropertyChanged += (object sender, PropertyChangedEventArgs e) => SetLoading(vm.Loading);
        }

        private void LoginButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {

            Frame.Navigate(typeof(LoginPage));
        }

        private void SetLoading(bool isLoading)
        {
            if (isLoading)
            {
                loading.Visibility = Visibility.Visible;
                loading.IsActive = true;
                registerBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                loading.Visibility = Visibility.Collapsed;
                loading.IsActive = false;
                registerBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
