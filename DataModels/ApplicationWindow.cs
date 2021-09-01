using BoxBoost.ValueConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.DataModels
{
    internal class WindowStorage
    {
        List<IWindow> WindowSa = new List<IWindow>();
        
        internal void AddWindow(ApplicationWindow newWindow) => WindowSa.Add((IWindow)new ApplicationWindowValueConverter().Convert(newWindow));

        internal void RemoveWindow()
        {

        }
        
    }

    internal interface IWindow
    {

    }

    public enum ApplicationWindow
    {
        None = 0,
        MainWin = 1,
        BoostWin = 2,
    }
}
