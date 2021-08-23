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
        /// Добавить слайд и исчезание в анимацию
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
    }
}
