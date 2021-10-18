using BoxBoost.DataModels;
using BoxBoost.Infrastructure.Commands;
using BoxBoost.ValueConverters;
using BoxBoost.ViewModels.Base;
using E1337.BoostWorker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        #region Размер режима

        private double _ModeHeight;

        [XmlIgnore]
        public double ModeHeight
        {
            get => _ModeHeight;
            set => Set(ref _ModeHeight, value);
        }

        #endregion

        #endregion

        #region Commands

        #region Добавить ссылку в список
        [XmlIgnore]
        public ICommand AddLinkCommand { get; set; }

        private void OnAddLinkCommandExecute(object p)
        {
            if(!string.IsNullOrEmpty(InLink))
                ListLinkBoost.Add(InLink);
        }

        private bool CanAddLinkCommandExecute(object p) => true;

        #endregion

        #region Удалить ссылку из списка
        [XmlIgnore]
        public ICommand DeleteLinkCommand { get; set; }

        private void OnDeleteLinkCommandExecute(object p)
        {
            if(p != null && ListLinkBoost.IndexOf(p.ToString()) != -1)
                ListLinkBoost.Remove(p.ToString());
        }

        private bool CanDeleteLinkCommandExecute(object p) => true;

        #endregion

        #region Скрыть по режиму
        [XmlIgnore]
        public ICommand CheckVisibleCommand { get; set; }

        private void OnCheckVisibleCommandExecute(object p)
        {
            if (Site != SiteList.OldPromoDJ.ToString() && Site != SiteList.PromoDJ.ToString())
                ModeHeight = 0;
            else
                ModeHeight = 40;
        }

        private bool CanCheckVisibleCommandExecute(object p) => true;

        #endregion

        #endregion


        #region Constructor

        public SettingsMainViewModel()
        {
            #region команды
            DeleteLinkCommand = new LambdaCommand(OnDeleteLinkCommandExecute, CanDeleteLinkCommandExecute);
            AddLinkCommand = new LambdaCommand(OnAddLinkCommandExecute, CanAddLinkCommandExecute);
            CheckVisibleCommand = new LambdaCommand(OnCheckVisibleCommandExecute, CanCheckVisibleCommandExecute);
            #endregion

            InitializeFillColection(ref _ListBoostSiteItem, Enum.GetNames(typeof(SiteList)));
            InitializeFillColection(ref _ListModeItem, Enum.GetNames(typeof(ModeList)));
            ListLinkBoost = new ObservableCollection<string>();
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
