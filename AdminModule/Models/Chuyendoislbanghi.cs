using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace AdminModule.Models
{
    public class Chuyendoislbanghi : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"({value.ToString()} bản ghi)";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
