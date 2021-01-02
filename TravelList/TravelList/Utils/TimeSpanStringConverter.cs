using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace TravelList.Utils
{
    public class TimeSpanStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value).ToString("HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.Parse((string)value);
        }
    }
}
