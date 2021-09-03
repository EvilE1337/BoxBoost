using BoxBoost.ValueConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BoxBoost.DataModels
{
    static internal class TaskManager
    {
        static List<TaskCollectionStruct> TaskList = new List<TaskCollectionStruct>();
        
        private class TaskCollectionStruct
        {
            /// <summary>Время создания</summary>
            public string DateTimeTask { get; set; }

            /// <summary>Ссылки</summary>
            public string LinksTask { get; set; }

            /// <summary>Подробная информация</summary>
            private string InfoTask { get; set; }

            /// <summary>Команда перезапуска</summary>
            public ICommand CommandReset { get; set; }

            /// <summary>Команда отключения</summary>
            public ICommand CommandShutdown { get; set; }

            /// <summary>Окно</summary>
            public Window AppWin { get; set; }
        }

        static internal void Delete(Window _window)
        {

        }

        static internal void Create(Window _window)
        {
            
        }

    }
}
