using BoxBoost.DataModels;
using BoxBoost.Infrastructure.Commands;
using BoxBoost.Infrastructure.Extensions;
using BoxBoost.Infrastructure.Helpers;
using BoxBoost.Services;
using BoxBoost.ViewModels.Base;
using E1337.BoostWorker;
using E1337.ProxyWorker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static BoxBoost.Services.Log4netLvl;

namespace BoxBoost.ViewModels
{
    internal class BoostWindowViewModel : ViewModel
    {
        #region Controls

        #region Основные настройки

        private SettingsMainViewModel _MainSettings;

        public SettingsMainViewModel MainSettings
        {
            get => _MainSettings;
            set => Set(ref _MainSettings, value);
        }

        #endregion

        #region Доп настройки

        private SettingsOtherViewModel _OtherSettings;

        public SettingsOtherViewModel OtherSettings
        {
            get => _OtherSettings;
            set => Set(ref _OtherSettings, value);
        }

        #endregion

        #region BestProxie настройки

        private SettingsBestProxieViewModel _BestProxieSettings;

        public SettingsBestProxieViewModel BestProxieSettings
        {
            get => _BestProxieSettings;
            set => Set(ref _BestProxieSettings, value);
        }

        #endregion

        #region Коллекция информации для вывода

        private ObservableCollection<OutInformationStruct> _ListViewOutInfoItem;

        public ObservableCollection<OutInformationStruct> ListViewOutInfoItem
        {
            get => _ListViewOutInfoItem;
            set => Set(ref _ListViewOutInfoItem, value);
        }

        public class OutInformationStruct
        {
            /// <summary>Информация</summary>
            public string InformationText { get; set; }

            /// <summary>Цвет</summary>
            public Brush ColorText { get; set; }
        }

        #endregion

        #region Рамка окна

        /// <summary> Контрол окна </summary>
        private Window mWindow;

        #endregion

        #region Заголовок окна
        /// <summary>Заголовок</summary>
        private string _Title = "BoxBoost[DebugVersion]";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region Текст на линке в подвале окна
        /// <summary>Заголовок</summary>
        private string _LinkText = "By E1337";

        public string LinkText
        {
            get => _LinkText;
            set => Set(ref _LinkText, value);
        }
        #endregion
        
        #region Статус операции
        /// <summary> Статус операции </summary>
        private int _StatusOperBar = 0;

        public int StatusOperBar
        {
            get => _StatusOperBar;
            set => Set(ref _StatusOperBar, value);
        }
        #endregion
        
        #endregion

        #region Commands

        #region Отображение меню окна

        public ICommand MenuCommand { get; set; }

        private void OnMenuCommandExecute(object p)
        {
            //here use fichas)
        }

        private bool CanMenuCommandExecute(object p) => true;

        #endregion

        #region Уменьшение окна

        public ICommand MinimizeCommand { get; set; }

        private void OnMinimizeCommandExecute(object p)
        {
            mWindow.WindowState = WindowState.Minimized;
        }

        private bool CanMinimizeCommandExecute(object p) => true;

        #endregion

        #region Закрытие окна

        public ICommand CloseCommand { get; set; }

        private void OnCloseCommandExecute(object p)
        {
            mWindow.Close();
        }

        private bool CanCloseCommandExecute(object p) => true;

        #endregion

        #endregion

        #region Constructor

        public BoostWindowViewModel(Window window)
        {
            mWindow = window;

            ListViewOutInfoItem = new ObservableCollection<OutInformationStruct>();

            FillSettings();
            FillCommand();

            LaunchAsync();
        }

        #endregion

        #region Helper

        private void FillSettings()
        {
            BestProxieSettings = SettingHelper.LoadSetting(new SettingsBestProxieViewModel());
            MainSettings = SettingHelper.LoadSetting(new SettingsMainViewModel());
            OtherSettings = SettingHelper.LoadSetting(new SettingsOtherViewModel());
        }

        private void FillCommand()
        {
            #region Команды

            #region Системные

            MinimizeCommand = new LambdaCommand(OnMinimizeCommandExecute, CanMinimizeCommandExecute);
            CloseCommand = new LambdaCommand(OnCloseCommandExecute, CanCloseCommandExecute);
            MenuCommand = new LambdaCommand(OnMenuCommandExecute, CanMenuCommandExecute);

            #endregion

            #endregion
        }

        private async void LaunchAsync()
        {
            MessageUpdate("Запуск...", OutLvl.Good);
            List<string> Proxy = await GetProxy();
            int CountProxy = Proxy.Count;
            MessageUpdate("Получено " + CountProxy + " прокси", CountProxy > 0 ? OutLvl.Good : OutLvl.Err);
            await RunBoost(MainSettings.ListLinkBoost);
        }

        private async Task RunBoost(List<string> Proxy)
        {
            IBoostSite BoostSite = GetBoostSite(Proxy);
            BoostSite.LaunchBoost(MainSettings.ListLinkBoost);
        }

        private IBoostSite GetBoostSite(List<string> Proxy)
        {
            switch (MainSettings.Site.ToEnum<SiteList>())
            {
                case SiteList.PromoDJ:
                    return new PromoDJ(new SettingsPromoDJ()
                    {
                        CountStream = MainSettings.CountStream,
                        Mode = MainSettings.Mode.ToEnum<ModeList>(),
                        LuckyRnd = MainSettings.RandomMode,
                        ProxyList = Proxy,
                        Pause = OtherSettings.Pause,
                        PercentDownLoad = OtherSettings.DownloadPercent,
                        PercentPlay = OtherSettings.PlayTime,
                        UseProxyRepeat = OtherSettings.UseProxyRepeat
                    });
                case SiteList.SoundCloud:
                    break;
            }
            return null;
        }

        private async Task<List<string>> GetProxy()
        {
            MessageUpdate("Начало получения прокси", OutLvl.Info);

            List<string> OutListProxy = new List<string>();
            List<Task> tasks = new List<Task>();
            List<IProxy> proxyContainer = FillProxyContainer();

            proxyContainer.ForEach(f =>
            {
                tasks.Add(Task.Run(() =>
                {
                    OutListProxy.AddRange(f.GetProxyAsync(OtherSettings.CheckProxy).Result);
                }));
            });

            await Task.WhenAll(tasks);

            return OutListProxy;
        }

        private List<IProxy> FillProxyContainer()
        {
            List<IProxy> proxyContainer = new List<IProxy>();

            if (!string.IsNullOrWhiteSpace(BestProxieSettings.Key))
            {
                ArgsService argsService = new ArgsService()
                {
                    Key = BestProxieSettings.Key,
                    Http = BestProxieSettings.Http,
                    Https = BestProxieSettings.Https,
                    Socks4 = BestProxieSettings.Socks4,
                    Socks5 = BestProxieSettings.Socks5,
                    Elite = BestProxieSettings.Elite,
                    Anonim = BestProxieSettings.Anonim,
                    Transparent = BestProxieSettings.Transparent,
                    Fast = BestProxieSettings.Fast,
                    Medium = BestProxieSettings.Medium,
                    Slow = BestProxieSettings.Slow,
                    Limit = "0",
                    Country = BestProxyCountry.GetReplaceOnValueList(BestProxieSettings.CountryList.Where(w => w.IsSelected).Select(s => s.NameCountry).ToList())
                };

                Action<string> delegateMsg = (msg) => MessageUpdate(msg);
                Action<int> delegateStatus = (status) => StatusOperBar = status;

                proxyContainer.Add(new BestProxie(MainSettings.ListLinkBoost[0], argsService, ref delegateMsg, ref delegateStatus));
            }

            return proxyContainer;
        }

        private void MessageUpdate(string msg, OutLvl lvl = OutLvl.Info)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                ListViewOutInfoItem.Add(new OutInformationStruct()
                {
                    ColorText = ColorLvl[lvl],
                    InformationText = msg
                });
                AddLog(msg, lvl);
            });
        }

        private readonly Dictionary<OutLvl, SolidColorBrush> ColorLvl = new Dictionary<OutLvl, SolidColorBrush>
        {
            {OutLvl.Err, Brushes.Red},
            {OutLvl.Info, Brushes.DarkGray},
            {OutLvl.Good, Brushes.Green}
        };

        #endregion
    }
}
