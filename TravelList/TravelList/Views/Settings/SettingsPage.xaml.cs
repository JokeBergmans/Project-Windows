using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

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
        }

       /* private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (Window.Current.Content is FrameworkElement frameworkElement)
                {
                    LinearGradientBrush gridBackground = Application.Current.Resources["GridBackground"] as LinearGradientBrush;
                    GradientStopCollection stops = gridBackground.GradientStops;
                    SolidColorBrush elementBackground = Application.Current.Resources["ElementBackground"] as SolidColorBrush;
                    SolidColorBrush navigationViewTopPaneBackground = Application.Current.Resources["NavigationViewTopPaneBackground"] as SolidColorBrush;
                    SolidColorBrush navigationViewExpandedPaneBackground = Application.Current.Resources["NavigationViewExpandedPaneBackground"] as SolidColorBrush;
                    SolidColorBrush navigationViewDefaultPaneBackground = Application.Current.Resources["NavigationViewDefaultPaneBackground"] as SolidColorBrush;
                    if (toggleSwitch.IsOn == true)
                    {
                        stops[0].Color = Color.FromArgb(0xFF, 0x09, 0x20, 0x3F);
                        stops[1].Color = Color.FromArgb(0xFF, 0x53, 0x78, 0x95);
                        gridBackground.Opacity = 1;
                        navigationViewTopPaneBackground.Color = Color.FromArgb(0xFF, 0x4E, 0x72, 0xA0);
                        navigationViewTopPaneBackground.Opacity = 0.8;
                        navigationViewExpandedPaneBackground.Color = Color.FromArgb(0xFF, 0x4E, 0x72, 0xA0);
                        navigationViewDefaultPaneBackground.Color = Color.FromArgb(0xFF, 0x4E, 0x72, 0xA0);

                    }
                    //frameworkElement.RequestedTheme = ElementTheme.Dark;
                    else
                    {
                        stops[0].Color = Color.FromArgb(0xFF, 0xAC, 0xE0, 0xF9);
                        stops[1].Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                        gridBackground.Opacity = 0.6;
                        navigationViewTopPaneBackground.Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                        navigationViewTopPaneBackground.Opacity = 0.8;
                        navigationViewExpandedPaneBackground.Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                        navigationViewDefaultPaneBackground.Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                    }
                        //frameworkElement.RequestedTheme = ElementTheme.Light;

                }
            }
        }*/
    }
}
