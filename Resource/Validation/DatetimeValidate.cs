using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Resource.Validation
{
    public class DatetimeValidate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime dateTime;
            bool result = DateTime.TryParse(value.ToString(),out dateTime);
            if (result) return ValidationResult.ValidResult;
            return new ValidationResult(false,"Lỗi ngày tháng");
        }
    }
}
