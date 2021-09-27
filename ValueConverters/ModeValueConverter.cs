using E1337.BoostWorker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ValueConverters
{
    public class ModeValueConverter : BaseValueConverter<ModeValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value != null)
            {
                switch (value.ToString())
                {
                    case nameof(ModeList.All):
                        return "Общий режим";
                    case nameof(ModeList.AllMainDownload):
                        return "Больше скачиваний";
                    case nameof(ModeList.AllMainPlay):
                        return "Больше прослушиваний";
                    case nameof(ModeList.AllRandom):
                        return "Случайный режим";
                    case nameof(ModeList.OnlyDownload):
                        return "Только скачивания";
                    case nameof(ModeList.OnlyPlay):
                        return "Только прослушивания";
                    case nameof(ModeList.OnlyView):
                        return "______________";
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
