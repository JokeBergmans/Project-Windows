using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TravelList.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Fields
        private bool _darkMode;
        #endregion

        #region Properties
        public bool DarkMode
        {
            get { return _darkMode; }
            set
            {
                _darkMode = value;
                // TODO: API call
                SetColors();
            }
        }
        #endregion

        #region Constructors
        public SettingsViewModel()
        {
            // TODO: API call
            DarkMode = false;
        }
        #endregion

        #region Methods
        private void SetColors()
        {
            LinearGradientBrush gridBackground = Application.Current.Resources["GridBackground"] as LinearGradientBrush;
            GradientStopCollection stops = gridBackground.GradientStops;
            SolidColorBrush buttonBackground = Application.Current.Resources["ButtonBackground"] as SolidColorBrush;
            SolidColorBrush buttonBackgroundPointerOver = Application.Current.Resources["ButtonBackgroundPointerOver"] as SolidColorBrush;
            SolidColorBrush navigationViewTopPaneBackground = Application.Current.Resources["NavigationViewTopPaneBackground"] as SolidColorBrush;
            SolidColorBrush navigationViewExpandedPaneBackground = Application.Current.Resources["NavigationViewExpandedPaneBackground"] as SolidColorBrush;
            SolidColorBrush navigationViewDefaultPaneBackground = Application.Current.Resources["NavigationViewDefaultPaneBackground"] as SolidColorBrush;

            if (DarkMode)
            {
                stops[0].Color = Color.FromArgb(0xFF, 0x09, 0x20, 0x3F);
                stops[1].Color = Color.FromArgb(0xFF, 0x53, 0x78, 0x95);
                gridBackground.Opacity = 1;
                navigationViewTopPaneBackground.Color = Color.FromArgb(0xFF, 0x4E, 0x72, 0xA0);
                navigationViewTopPaneBackground.Opacity = 0.8;
                navigationViewExpandedPaneBackground.Color = Color.FromArgb(0xFF, 0x4E, 0x72, 0xA0);
                navigationViewDefaultPaneBackground.Color = Color.FromArgb(0xFF, 0x4E, 0x72, 0xA0);
                buttonBackground.Color = Colors.White;
                buttonBackgroundPointerOver.Color = Colors.LightGray;

            }
            else
            {
                stops[0].Color = Color.FromArgb(0xFF, 0xAC, 0xE0, 0xF9);
                stops[1].Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                gridBackground.Opacity = 0.6;
                navigationViewTopPaneBackground.Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                navigationViewTopPaneBackground.Opacity = 0.8;
                navigationViewExpandedPaneBackground.Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                navigationViewDefaultPaneBackground.Color = Color.FromArgb(0xFF, 0xFB, 0xC8, 0xD4);
                buttonBackground.Color = Colors.LightBlue;
                buttonBackgroundPointerOver.Color = Colors.SkyBlue;
            }
        }
        #endregion
    }
}
