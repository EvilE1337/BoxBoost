using BoxBoost.DataModels;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace BoxBoost.ValueConverters
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.SettingsBestProxieFrame:
                    return PageStorage.CurrentPage = new Pages.SettingsBestProxieFrame();
                case ApplicationPage.SettingsLocalProxyFrame:
                    return PageStorage.CurrentPage = new Pages.SettingsLocalProxyFrame();
                default:
                    PageStorage.CurrentPage = null;
                    //Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value != null)
                switch (value.GetType().Name)
                {
                    case "SettingsBestProxieFrame":
                        return ApplicationPage.SettingsBestProxieFrame;
                    case "SettingsLocalProxyFrame":
                        return ApplicationPage.SettingsLocalProxyFrame;
                    default:
                        return ApplicationPage.None;

                }
            else
                return ApplicationPage.None;
        }
    }
}
