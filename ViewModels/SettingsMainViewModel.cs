using BoxBoost.DataModels;
using BoxBoost.ViewModels.Base;
using E1337.BoostWorker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoxBoost.ViewModels
{
    public class SettingsMainViewModel : MainSettings
    {
        #region Controls

        #region Коллекция списка сайтов
        
        private ObservableCollection<string> _ListBoostSiteItem;

        [XmlIgnore]
        public ObservableCollection<string> ListBoostSiteItem
        {
            get => _ListBoostSiteItem;
            set => Set(ref _ListBoostSiteItem, value);
        }

        #endregion

        #region Коллекция режимов
        
        private ObservableCollection<string> _ListModeItem;

        [XmlIgnore]
        public ObservableCollection<string> ListModeItem
        {
            get => _ListModeItem;
            set => Set(ref _ListModeItem, value);
        }

        #endregion

        #region Введенная ссылка

        private string _InLink;

        public string InLink
        {
            get => _InLink;
            set => Set(ref _InLink, value);
        }

        #endregion

        #endregion


        #region Constructor

        public SettingsMainViewModel()
        {
            InitializeFillColection(ref _ListBoostSiteItem, Enum.GetNames(typeof(SiteList)));
            InitializeFillColection(ref _ListModeItem, Enum.GetNames(typeof(ModeList)));
            ListLinkBoost = new List<string>()
            {
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
