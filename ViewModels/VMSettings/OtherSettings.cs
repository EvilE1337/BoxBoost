using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ViewModels.VMSettings
{
    [Serializable]
    public abstract class OtherSettings : ViewModel
    {
        #region Дополнительные настройки

        #region Пауза между операциями
        /// <summary>Пауза между операциями</summary>
        private int _Pause;

        public int Pause
        {
            get => _Pause;
            set => Set(ref _Pause, value);
        }
        #endregion

        #region Таймер вкл/выкл
        /// <summary>Таймер вкл/выкл</summary>
        private bool _Timer;

        public bool Timer
        {
            get => _Timer;
            set => Set(ref _Timer, value);
        }
        #endregion

        #region Время прослушивания
        /// <summary>Время прослушивания</summary>
        private int _PlayTime;

        public int PlayTime
        {
            get => _PlayTime;
            set => Set(ref _PlayTime, value);
        }
        #endregion

        #region Процент скачивания
        /// <summary>Процент скачивания</summary>
        private int _DownloadPercent;

        public int DownloadPercent
        {
            get => _DownloadPercent;
            set => Set(ref _DownloadPercent, value);
        }
        #endregion

        #region Видимость процесса
        /// <summary>Видимость процесса</summary>
        private bool _ViewProcess;

        public bool ViewProcess
        {
            get => _ViewProcess;
            set => Set(ref _ViewProcess, value);
        }
        #endregion

        #region Использовать прокси повторно
        /// <summary>Использовать прокси повторно</summary>
        private bool _UseProxyRepeat;

        public bool UseProxyRepeat
        {
            get => _UseProxyRepeat;
            set => Set(ref _UseProxyRepeat, value);
        }
        #endregion

        #region Проверка прокси
        /// <summary>Проверка прокси</summary>
        private bool _CheckProxy;

        public bool CheckProxy
        {
            get => _CheckProxy;
            set => Set(ref _CheckProxy, value);
        }
        #endregion

        #endregion
    }
}
