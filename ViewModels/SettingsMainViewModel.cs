using BoxBoost.ViewModels.Base;
using E1337.BoostWorker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ViewModels
{
    public class SettingsMainViewModel : ViewModel
    {
        #region Controls

        #region Ссылки для буста

        private List<string> _ListLinkBoostItem;

        public List<string> ListLinkBoostItem
        {
            get => _ListLinkBoostItem;
            set => Set(ref _ListLinkBoostItem, value);
        }

        #endregion

        #region Коллекция списка сайтов

        private ObservableCollection<string> _ListBoostSiteItem;
        
        public ObservableCollection<string> ListBoostSiteItem
        {
            get => _ListBoostSiteItem;
            set => Set(ref _ListBoostSiteItem, value);
        }

        #endregion

        #region Коллекция режимов

        private ObservableCollection<string> _ListModeItem;

        public ObservableCollection<string> ListModeItem
        {
            get => _ListModeItem;
            set => Set(ref _ListModeItem, value);
        }

        #endregion

        #endregion


        #region Constructor

        public SettingsMainViewModel()
        {
            InitializeFillColection(ref _ListBoostSiteItem, Enum.GetNames(typeof(SiteList)));
            InitializeFillColection(ref _ListModeItem, Enum.GetNames(typeof(ModeList)));
            ListLinkBoostItem = new List<string>()
            {
                "wewew",
                "wewew"
            };
        }

        #endregion

        #region Helper

        private void InitializeFillColection(ref ObservableCollection<string> _collection, string[] _data)
        {
            _collection = new ObservableCollection<string>();
            foreach (string el in _data)
                _collection.Add(el);
        }

        #endregion
    }
}
