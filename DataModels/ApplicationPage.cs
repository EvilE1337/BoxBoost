using BoxBoost.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BoxBoost.DataModels
{
    internal static class PageStorage
    {
        private static BasePage _CurrentPage;

        public static BasePage CurrentPage
        {
            get => _CurrentPage;
            set
            {
                ValueConverters.ApplicationPageValueConverter converter = new ValueConverters.ApplicationPageValueConverter();
                object newPage = converter.ConvertBack(value);
                object oldPage = converter.ConvertBack(_CurrentPage);
                bool isNext = newPage != null && oldPage != null && (ApplicationPage)newPage > (ApplicationPage)oldPage;
                _CurrentPage = value;
                LoadedPage(isNext);
            }
        }

        private static void LoadedPage(bool isNext)
        {
            if (_CurrentPage != null)
                _CurrentPage.Loaded += async (sender, e) => 
                await _CurrentPage.AnimationAsync(isNext ? Animation.PageAnimation.SlideAndFadeInFromRight : Animation.PageAnimation.SlideAndFadeInFromLeft);
        }

        public static async Task BeforeUnloadPage(bool isBack)
        {
            if(CurrentPage != null && CurrentPage.IsLoaded)
                await CurrentPage.AnimationAsync(isBack? Animation.PageAnimation.SlideAndFadeOutToRight : Animation.PageAnimation.SlideAndFadeOutToLeft);
        }
    }

    public enum ApplicationPage
    {
        TaskOutputFrame = 0,
        SettingsMainFrame = 1,
        SettingsOtherFrame = 2,
        SettingsLocalProxyFrame = 3,     
        SettingsBestProxieFrame = 4,

    }   
}
