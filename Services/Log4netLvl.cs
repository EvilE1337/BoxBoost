using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using log4net;
using log4net.Config;

namespace BoxBoost.Services
{
    internal static class Log4netLvl
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Log4netLvl));

        static Log4netLvl() => XmlConfigurator.Configure();

        internal enum OutLvl
        {
            Err,
            Info,
            Good
        }

        internal static void AddLog(string msg, OutLvl lvl)
        {
            switch(lvl)
            {
                case OutLvl.Err:
                    log.Error(msg);
                    break;
                case OutLvl.Good:
                    log.Info(msg);
                    break;
                case OutLvl.Info:
                    log.Info(msg);
                    break;
            }
        }
    }
}
