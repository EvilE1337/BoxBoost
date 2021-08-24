using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BoxBoost.Animation
{
    public static class PageAnimations
    {

        /// <summary>
        /// Страница выкатывается справа
        /// </summary>
        /// <param name="page">Страница с анимацией</param>
        /// <param name="seconds">Время анимации</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            // Добавляем слайд выкатывающийся из правой стороны
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            // Добавляем исчезновение анимации
            sb.AddFadeIn(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Страница укатывается влево
        /// </summary>
        /// <param name="page">Страница с анимацией</param>
        /// <param name="seconds">Время анимации</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            // Добавляем слайд укатывающий страницу в левую сторону
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            // Добавляем исчезновение анимации
            sb.AddFadeOut(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
    }
}
