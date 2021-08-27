using BoxBoost.DataModels;
using BoxBoost.ViewModels.Base;
using System.Collections.ObjectModel;

namespace BoxBoost.ViewModels
{
    public class SettingsBestProxieViewModel : ViewModel
    {
        #region Controls

        #region Лист стран

        private ObservableCollection<BoolStringStruct> _CountryList;

        public ObservableCollection<BoolStringStruct> CountryList
        {
            get => _CountryList;
            set => Set(ref _CountryList, value);
        }

        public class BoolStringStruct : ViewModel
        {
            /// <summary>Название страны</summary>
            public string _NameCountry { get; set; }

            /// <summary>Отмечено</summary>
            public bool _IsSelected { get; set; }
        }

        #endregion

        #endregion

        #region Команды



        #endregion

        #region constructor

        public SettingsBestProxieViewModel()
        {
            CountryList = new ObservableCollection<BoolStringStruct>();
            CountryList.Add(new BoolStringStruct { _IsSelected = true, _NameCountry = "Some text for item #1" });
            CountryList.Add(new BoolStringStruct { _IsSelected = false, _NameCountry = "Some text for item #2" });
            CountryList.Add(new BoolStringStruct { _IsSelected = false, _NameCountry = "Some text for item #3" });

            #region Команды



            #endregion

        }

        #endregion
    }
}
