using BoxBoost.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ValueConverters
{
    public class ApplicationPageName : BaseValueConverter<ApplicationPageName>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value != null)
            {
                switch (value.ToString())
                {
                    case "TaskOutputFrame":
                        return "Управление задачами";
                    case "SettingsBestProxieFrame":
                        return "Сервис BestProxie";
                    case "SettingsLocalProxyFrame":
                        return "Локальные прокси";
                    case "SettingsMainFrame":
                        return "Основные";
                    case "SettingsOtherFrame":
                        return "Дополнительные";
                    default:
                        return "Без названия";

                }
            }
            return string.Empty;
        }

        public override object ConvertBack(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            throw new NotImplementedException();
        }
    }
}
