using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.Animation
{
    /// <summary>
    /// Стили анимированной страницы
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// Без анимации
        /// </summary>
        None = 0,
        /// <summary>
        /// Уходим вправо
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// Уходим влево
        /// </summary>
        SlideAndFadeInFromLeft = 2,
    }
}
