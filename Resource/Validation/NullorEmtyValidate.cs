using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Resource.Validation
{
    public class NullorEmtyValidate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length>3) return new ValidationResult(false,"rỗng");
            return ValidationResult.ValidResult;
        }
    }
}
