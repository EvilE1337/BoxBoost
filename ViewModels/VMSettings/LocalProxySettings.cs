using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ViewModels.VMSettings
{
    [Serializable]
    public abstract class LocalProxySettings : ViewModel
    {
        #region Настройка LocalProxy

        #region Прокси из файла

        /// <summary>Прокси из файла</summary>
        private ObservableCollection<string> _ListProxyFileItem;

        public ObservableCollection<string> ListProxyFileItem
        {
            get => _ListProxyFileItem;
            set => Set(ref _ListProxyFileItem, value);
        }

        #endregion

        #endregion
    }
}
