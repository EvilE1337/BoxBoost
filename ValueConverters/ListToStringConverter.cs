using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ValueConverters
{
    public class ListToStringConverter : BaseValueConverter<ListToStringConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a String");

            return String.Join("\r\n", ((IList<string>)value).ToArray());
        }

        public override object ConvertBack(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            throw new NotImplementedException();
        }
    }
}
