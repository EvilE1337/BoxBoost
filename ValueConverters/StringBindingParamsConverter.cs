using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ValueConverters
{
    public class StringBindingParamsConverter : BaseValueConverter<StringBindingParamsConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            return string.Format(parameter as string, value);
        }

        public override object ConvertBack(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            throw new NotImplementedException();
        }
    }
}
