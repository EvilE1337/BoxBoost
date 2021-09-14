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
        private static List<TaskCollectionStruct> TaskList = new List<TaskCollectionStruct>();
        
        public class TaskCollectionStruct
        {
            /// <summary>Время создания</summary>
            public string DateTimeTask { get; set; }

            /// <summary>Окно</summary>
            public BoostWindow AppWin { get; set; }
        }

        static internal void Create(BoostWindow _window)
        {
            TaskList.Add(new TaskCollectionStruct()
            {
                DateTimeTask = DateTime.Now.ToString(),
                AppWin = _window
            });
        }

        static internal List<TaskCollectionStruct> GetTaskList()
        {
            // заюзать проверку на права или еще что-нибудь
            return TaskList;
        }

    }
}
