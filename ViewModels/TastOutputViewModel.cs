using BoxBoost.DataModels;
using BoxBoost.Infrastructure.Commands;
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
            public ObservableCollection<string> LinksTask { get; set; }

            /// <summary>Прослушивания</summary>
            public int CountPlayTask { get; set; }

            /// <summary>Скачивания</summary>
            public int CountDownloadTask { get; set; }

            /// <summary>Статус</summary>
            public bool StatusActive { get; set; }

            /// <summary>Команда отключения</summary>
            public ICommand CommandShutdown { get; set; }
        }

        #endregion

        #endregion

        #region Constructor

        public TastOutputViewModel()
        {
            CicleCheckTasksAsync();
        }

        #endregion
        
        #region Helper
        
        private async void CicleCheckTasksAsync()
        {
            while (true)
            {
                FillTasks();
                await Task.Delay(5000);
            }
        }

        private void FillTasks()
        {
            TaskCollection = new ObservableCollection<TaskCollectionStruct>();
            List<TaskManager.TaskCollectionStruct> Tasks = TaskManager.GetTaskList();
            Tasks.ForEach(f =>
            {
                BoostWindowViewModel _DataContext = ((BoostWindowViewModel)f.AppWin.DataContext);
                TaskCollectionStruct TaskObj = new TaskCollectionStruct()
                {
                    DateTimeTask = f.DateTimeTask,
                    CommandShutdown = new LambdaCommand((object obj) => f.AppWin.Close(), (object obj) => true),
                    LinksTask = _DataContext.MainSettings.ListLinkBoost,
                    CountDownloadTask = _DataContext.CountDownload,
                    CountPlayTask = _DataContext.CountPlay,
                    StatusActive = f.AppWin.IsLoaded
                };
                TaskCollection.Add(TaskObj);
            });
        }


        #endregion
    }
}
