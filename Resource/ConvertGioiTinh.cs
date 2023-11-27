

using System;
using System.Globalization;
using System.Windows.Data;

namespace Resource
{
    public class ConvertGioiTinh : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value) return "Nam";
            return "Nữ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
