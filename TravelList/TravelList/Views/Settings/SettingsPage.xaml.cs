using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelList.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            tsDarkMode.IsOn = (Application.Current.RequestedTheme == ApplicationTheme.Dark || ((FrameworkElement)Window.Current.Content).RequestedTheme == ElementTheme.Dark);
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (Window.Current.Content is FrameworkElement frameworkElement)
                {
                    if (toggleSwitch.IsOn == true)
                        frameworkElement.RequestedTheme = ElementTheme.Dark;
                    else
                        frameworkElement.RequestedTheme = ElementTheme.Light;
                }
            }
        }
    }
}
