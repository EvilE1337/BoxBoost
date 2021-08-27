using BoxBoost.DataModels;
using BoxBoost.Infrastructure.Commands;
using BoxBoost.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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

        /// <summary>Заголовок</summary>
        private ApplicationPage _CurrentPage = ApplicationPage.SettingsBestProxieFrame;

        public ApplicationPage CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value);
        }
        #endregion

        #region Команды



        #endregion

        public SettingsBestProxieViewModel()
        {
            CountryList = new ObservableCollection<BoolStringStruct>();
            CountryList.Add(new BoolStringStruct { _IsSelected = true, _NameCountry = "Some text for item #1" });
            CountryList.Add(new BoolStringStruct { _IsSelected = false, _NameCountry = "Some text for item #2" });
            CountryList.Add(new BoolStringStruct { _IsSelected = false, _NameCountry = "Some text for item #3" });

            #region Команды



            #endregion

        }
        
    }
}
