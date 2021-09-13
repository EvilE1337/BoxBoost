using BoxBoost.DataModels;
using BoxBoost.Infrastructure.Commands;
using BoxBoost.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Serialization;

namespace BoxBoost.ViewModels
{
    public class SettingsBestProxieViewModel : BestProxieSettings
    {
        #region Controls

        #region Отмечено ЧБ
        /// <summary>Отмечено ЧБ</summary>
        private int _CountChecked = 0;

        public int CountChecked
        {
            get => _CountChecked;
            set => Set(ref _CountChecked, value);
        }
        #endregion

        #endregion

        #region Команды

        #region Очистить ЧБ
        [XmlIgnore]
        public ICommand ClearCheckBoxCommand { get; set; }

        private void OnClearCheckBoxCommandExecute(object p)
        {
            foreach(BoolStringStruct el in CountryList)
            {
                el.IsSelected = false;
            }
            CountChecked = 0;
        }

        private bool CanClearCheckBoxCommandExecute(object p) => true;

        #endregion

        #region Событие ЧБ
        [XmlIgnore]
        public ICommand CheckedEventCommand { get; set; }

        private void OnCheckedEventCommandExecute(object p)
        {
            CountChecked += System.Convert.ToInt32(p);
        }

        private bool CanCheckedEventCommandExecute(object p) => true;

        #endregion

        #endregion

        #region Constructor

        public SettingsBestProxieViewModel()
        {
            #region Команды
            ClearCheckBoxCommand = new LambdaCommand(OnClearCheckBoxCommandExecute, CanClearCheckBoxCommandExecute);
            CheckedEventCommand = new LambdaCommand(OnCheckedEventCommandExecute, CanCheckedEventCommandExecute);
            #endregion

        }
        
        #endregion

        #region Helper

        internal void FillCountry()
        {
            if (CountryList == null)
            {
                CountryList = new ObservableCollection<BoolStringStruct>();

                E1337.ProxyWorker.BestProxyCountry.GetNameCountryList().ForEach(f =>
                {
                    CountryList.Add(new BoolStringStruct { IsSelected = false, NameCountry = f });
                });
            }
        }

        #endregion
    }
}
