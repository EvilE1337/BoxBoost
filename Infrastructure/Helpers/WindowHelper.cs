using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BoxBoost.Infrastructure.Helpers
{
    static internal class WindowHelper
    {
        static internal Point GetMousePointion(Window mWindow)
        {
            Point position = Mouse.GetPosition(mWindow);
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }
    }
}
