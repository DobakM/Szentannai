using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BusinessCardWizard.Converter
{
    class PhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string format = parameter as string;

            string typed = value as string;

            if (string.IsNullOrEmpty(typed))
            {
                return null;
            }

            if (string.IsNullOrEmpty(format))
            {
                return null;
            }

            var digits = typed.Where(delegate (Char x) { return Char.IsDigit(x); });

            string array = new string(digits.ToArray());

            if (string.IsNullOrWhiteSpace(array))
            {
                return null;
            }

            long number = System.Convert.ToInt64(array);

            return string.Format(format, number).Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
