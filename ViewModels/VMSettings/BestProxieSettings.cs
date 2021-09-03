using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.DataModels
{
    public class BestProxieSettings : ViewModel
    {
        #region Настройка BestProxie

        #region Ключ
        /// <summary>Ключ</summary>
        private string _Key;

        public string Key
        {
            get => _Key;
            set => Set(ref _Key, value);
        }
        #endregion

        #region Типы
        /// <summary>Http</summary>
        private bool _Http;

        public bool Http
        {
            get => _Http;
            set => Set(ref _Http, value);
        }

        /// <summary>Https</summary>
        private bool _Https;

        public bool Https
        {
            get => _Https;
            set => Set(ref _Https, value);
        }

        /// <summary>Socks4</summary>
        private bool _Socks4;

        public bool Socks4
        {
            get => _Socks4;
            set => Set(ref _Socks4, value);
        }

        /// <summary>Socks5</summary>
        private bool _Socks5;

        public bool Socks5
        {
            get => _Socks5;
            set => Set(ref _Socks5, value);
        }
        #endregion

        #region Скорость
        /// <summary>Быстрая</summary>
        private bool _Fast;

        public bool Fast
        {
            get => _Fast;
            set => Set(ref _Fast, value);
        }

        /// <summary>Средняя</summary>
        private bool _Medium;

        public bool Medium
        {
            get => _Medium;
            set => Set(ref _Medium, value);
        }

        /// <summary>Медленная</summary>
        private bool _Slow;

        public bool Slow
        {
            get => _Slow;
            set => Set(ref _Slow, value);
        }
        #endregion

        #region Анонимность
        /// <summary>Элитные</summary>
        private bool _Elite;

        public bool Elite
        {
            get => _Elite;
            set => Set(ref _Elite, value);
        }

        /// <summary>Анонимные</summary>
        private bool _Anonim;

        public bool Anonim
        {
            get => _Anonim;
            set => Set(ref _Anonim, value);
        }

        /// <summary>Прозрачные</summary>
        private bool _Transparent;

        public bool Transparent
        {
            get => _Transparent;
            set => Set(ref _Transparent, value);
        }
        #endregion

        #region Страны
        /// <summary>Страны</summary>
        private List<string> _ListCountry;

        public List<string> ListCountry
        {
            get => _ListCountry;
            set => Set(ref _ListCountry, value);
        }
        #endregion

        #endregion
    }
}
