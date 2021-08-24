using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace BoxBoost.Animation
{
    /// <summary>
    /// Animation Helper for <see cref="StroryBoard"/>
    /// </summary>
    static class StoryboardHelpers
    {
        /// <summary>
        /// Анимация выкатывания окна из правой части
        /// </summary>
        /// <param name="strotyboard">Куда добавлять</param>
        /// <param name="second">Время анимации</param>
        /// <param name="offset">Расстояние справа</param>
        /// <param name="deceleration">Замедление скорости</param>
        public static void AddSlideFromRight(this Storyboard strotyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            var Animation = new ThicknessAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = 0.9f
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            strotyboard.Children.Add(Animation);
        }

        /// <summary>
        /// Анимация исчезновение окна влево
        /// </summary>
        /// <param name="strotyboard">Куда добавлять</param>
        /// <param name="second">Время анимации</param>
        /// <param name="offset">Расстояние справа</param>
        /// <param name="deceleration">Замедление скорости</param>
        public static void AddSlideToLeft(this Storyboard strotyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            var Animation = new ThicknessAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = 0.9f
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            strotyboard.Children.Add(Animation);
        }

        /// <summary>
        /// Анимация выкатывания окна из правой части
        /// </summary>
        /// <param name="strotyboard">Куда добавлять</param>
        /// <param name="second">Время анимации</param>
        public static void AddFadeIn(this Storyboard strotyboard, float seconds)
        {
            var Animation = new DoubleAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            strotyboard.Children.Add(Animation);
        }

        /// <summary>
        /// Анимация исчезновения окна влево
        /// </summary>
        /// <param name="strotyboard">Куда добавлять</param>
        /// <param name="second">Время анимации</param>
        public static void AddFadeOut(this Storyboard strotyboard, float seconds)
        {
            var Animation = new DoubleAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            strotyboard.Children.Add(Animation);
        }
    }
}
