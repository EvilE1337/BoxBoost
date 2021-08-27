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
    public class BasePage : Page
    {
        #region Controls

        bool HasAnimation = true;

        /// <summary>
        /// Время анимации
        /// </summary>
        public float SlideSecond { get; set; } = 0.8f;

        #endregion

        #region Constructor

        public BasePage()
        {
            if (HasAnimation)
                this.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        #region Animation Load / Unload
       
        public async Task AnimationAsync(PageAnimation animation)
        {
            if (animation == PageAnimation.None)
                return;

            switch (animation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(this.SlideSecond);
                    break;
                case PageAnimation.SlideAndFadeInFromLeft:
                    await this.SlideAndFadeInFromLeftAsync(this.SlideSecond);
                    break;
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeftAsync(this.SlideSecond);
                    break;
                case PageAnimation.SlideAndFadeOutToRight:
                    await this.SlideAndFadeOutToRightAsync(this.SlideSecond);
                    break;
            }
        }


        #endregion
    }

    public class BasePage<VM> : BasePage
        where VM : ViewModel, new()
    {
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
        
        #region Constructor

        public BasePage()
        {
            this.ViewModel = new VM();
        }

        #endregion
        
    }
}