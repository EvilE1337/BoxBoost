using BoxBoost.DataModels;
using BoxBoost.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BoxBoost.ViewModels
{
    public class SettingsBestProxieViewModel : BestProxieSettings
    {
        #region Controls

        #endregion

        #region Команды
        
        #endregion

        #region Constructor

        public SettingsBestProxieViewModel()
        {
            #region Команды

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
