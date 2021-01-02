using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TravelList.Utils
{
    public class ThemeUtil
    {
        private static Color _dark1 = Color.FromArgb(0xFF, 0x09, 0x20, 0x3F);
        private static Color _dark2 = Color.FromArgb(0xFF, 0x53, 0x78, 0x95);
        private static Color _dark3 = Color.FromArgb(0xFF, 0x4E, 0x72, 0xA0);

        private static Color _light1 = Color.FromArgb(0xFF, 0xAC, 0xE0, 0xF9);
        private static Color _light2 = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);

        public static void SetTheme(bool dark)
        {
            LinearGradientBrush gridBackground = Application.Current.Resources["GridBackground"] as LinearGradientBrush;
            GradientStopCollection stops = gridBackground.GradientStops;
            SolidColorBrush buttonBackground = Application.Current.Resources["ButtonBackground"] as SolidColorBrush;
            SolidColorBrush buttonBackgroundPointerOver = Application.Current.Resources["ButtonBackgroundPointerOver"] as SolidColorBrush;
            SolidColorBrush navigationViewTopPaneBackground = Application.Current.Resources["NavigationViewTopPaneBackground"] as SolidColorBrush;
            SolidColorBrush navigationViewExpandedPaneBackground = Application.Current.Resources["NavigationViewExpandedPaneBackground"] as SolidColorBrush;
            SolidColorBrush navigationViewDefaultPaneBackground = Application.Current.Resources["NavigationViewDefaultPaneBackground"] as SolidColorBrush;
            SolidColorBrush textOnBackground = Application.Current.Resources["TextOnBackground"] as SolidColorBrush;

            if (dark)
            {
                stops[0].Color = _dark1;
                stops[1].Color = _dark2;
                gridBackground.Opacity = 1;
                navigationViewTopPaneBackground.Color = _dark3;
                navigationViewTopPaneBackground.Opacity = 0.8;
                navigationViewExpandedPaneBackground.Color = _dark3;
                navigationViewDefaultPaneBackground.Color = _dark3;
                buttonBackground.Color = Colors.White;
                buttonBackgroundPointerOver.Color = Colors.LightGray;
                textOnBackground.Color = Colors.White;

            }
            else
            {
                stops[0].Color = _light1;
                stops[1].Color = _light2;
                gridBackground.Opacity = 0.6;
                navigationViewTopPaneBackground.Color = _light2;
                navigationViewTopPaneBackground.Opacity = 0.8;
                navigationViewExpandedPaneBackground.Color = _light2;
                navigationViewDefaultPaneBackground.Color = _light2;
                buttonBackground.Color = Colors.LightBlue;
                buttonBackgroundPointerOver.Color = Colors.SkyBlue;
                textOnBackground.Color = Colors.Black;
            }
        }
    }
}
