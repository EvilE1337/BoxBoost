using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoxBoost.ViewModels
{
    public class TastOutputViewModel : ViewModel
    {
        #region Controls

        #region Коллекция для вывода тасок

        private ObservableCollection<TaskCollectionStruct> _TaskCollection;

        public ObservableCollection<TaskCollectionStruct> TaskCollection
        {
            get => _TaskCollection;
            set => Set(ref _TaskCollection, value);
        }

        public class TaskCollectionStruct : ViewModel
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
        }

        #endregion

        #endregion

        #region Constructor

        public TastOutputViewModel()
        {
            TaskCollection = new ObservableCollection<TaskCollectionStruct>();
        }

        #endregion


        #region Helper
        

        #endregion
    }
}
