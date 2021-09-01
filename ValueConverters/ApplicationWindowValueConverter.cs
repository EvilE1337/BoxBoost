using System;
using BoxBoost.DataModels;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ValueConverters
{
    /// <summary>
    /// Converts the <see cref="ApplicationWindow"/> to an actual view/window
    /// </summary>
    public class ApplicationWindowValueConverter : BaseValueConverter<ApplicationWindowValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            switch ((ApplicationWindow)value)
            {
                case ApplicationWindow.MainWin:
                    return new MainWindow();
                case ApplicationWindow.BoostWin:
                    return  new BoostWindow();
                default:
                    //Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value != null)
                switch (value.GetType().Name)
                {
                    case "MainWin":
                        return ApplicationWindow.MainWin;
                    case "BoostWin":
                        return ApplicationWindow.BoostWin;
                    default:
                        return ApplicationWindow.None;

                }
            else
                return ApplicationWindow.None;
        }
    }
}
