using BoxBoost.Animation;
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
        #region откртые настройки

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUploadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

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
        }

        #endregion

        #region Animation Load / Unload

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimationIn();
        }

        public async Task AnimationIn()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.SlideAndFadeInFromRight:

                    await this.SlideAndFadeInFromRight(this.SlideSecond);

                    await Task.Delay((int)(this.SlideSecond * 1000));

                    break;
                case PageAnimation.SlideAndFadeInFromLeft:
                    break;
            }

            #endregion
            

        }
    }
}