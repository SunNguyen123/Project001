using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Resource
{
    public class ConvertDateTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = DateTime.Parse(value.ToString());
            return date.ToString("d-MM-yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrWhiteSpace(value.ToString())) 
            {
                DateTime date;
                if( !DateTime.TryParse(value.ToString(),out date))
                {
                    return null;
                }

                return date.ToString("yyyy-MM-d");
            }
            return null;

        }
    }
}
