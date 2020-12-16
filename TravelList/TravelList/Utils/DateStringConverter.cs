﻿using System;
using Windows.UI.Xaml.Data;

namespace TravelList.Utils
{
    class DateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value).ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.Parse((string)value);
        }
    }
}
