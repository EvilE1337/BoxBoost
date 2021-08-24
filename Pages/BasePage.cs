using BoxBoost.Animation;
using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BoxBoost.Pages
{
    public class BasePage<VM> : Page 
        where VM : ViewModel, new()
    {
        #region Controls

        #region VM page

        /// <summary>
        /// ViewModel page
        /// </summary>
        private VM _ViewModel;
        
        public VM ViewModel
        {
            get => _ViewModel;
            set
            {
                if (_ViewModel == value)
                    return;

                _ViewModel = value;

                this.DataContext = _ViewModel;
            }
        }

        #endregion

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Время анимации
        /// </summary>
        public float SlideSecond { get; set; } = 0.8f;
        
        #endregion

        #region Constructor

        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = System.Windows.Visibility.Collapsed;

            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM();
        }

        #endregion

        #region Animation Load / Unload

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimationIn();
        }

        public async Task AnimationIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.SlideAndFadeInFromRight:
                        await this.SlideAndFadeInFromRight(this.SlideSecond);
                    break;
            }
        }

        public async Task AnimationOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSecond);
                    break;
            }
        }


        #endregion


    }
}