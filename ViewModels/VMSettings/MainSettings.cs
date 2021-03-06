using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.DataModels
{
    [Serializable]
    public abstract class MainSettings : ViewModel
    {
        #region Основные настройки

        #region Сайт
        /// <summary>Сайт</summary>
        private string _Site;

        public string Site
        {
            get => _Site;
            set => Set(ref _Site, value);
        }
        #endregion

        #region Режим
        /// <summary>Режим</summary>
        private string _Mode;

        public string Mode
        {
            get => _Mode;
            set => Set(ref _Mode, value);
        }
        #endregion

        #region Вероятность
        /// <summary>Вероятность</summary>
        private int _RandomMode = 0;

        public int RandomMode
        {
            get => _RandomMode;
            set => Set(ref _RandomMode, value);
        }
        #endregion

        #region Число потоков
        /// <summary>Число потоков</summary>
        private int _CountStream = 0;

        public int CountStream
        {
            get => _CountStream;
            set => Set(ref _CountStream, value);
        }
        #endregion

        #region Ссылки для буста

        private ObservableCollection<string> _ListLinkBoost;

        public ObservableCollection<string> ListLinkBoost
        {
            get => _ListLinkBoost;
            set => Set(ref _ListLinkBoost, value);
        }

        #endregion

        #endregion
    }
}
