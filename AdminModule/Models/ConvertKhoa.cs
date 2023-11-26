using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using Libary_ConnectDB;
using Prism.Unity;
namespace AdminModule.Models
{
    public class ConvertKhoa : IValueConverter
    {
        
        public ConvertKhoa()
        {
            
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
