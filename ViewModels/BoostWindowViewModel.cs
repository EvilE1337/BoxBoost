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

        #region Local Proxy настройки

        private SettingsLocalProxyViewModel _LocalProxySettings;

        public SettingsLocalProxyViewModel LocalProxySettings
        {
            get => _LocalProxySettings;
            set => Set(ref _LocalProxySettings, value);
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

        #region Статус бары

        private ObservableCollection<StatusBarStruct> _StatusBars;

        public ObservableCollection<StatusBarStruct> StatusBars
        {
            get => _StatusBars;
            set => Set(ref _StatusBars, value);
        }

        public class StatusBarStruct : ViewModel
        {
            /// <summary>Название</summary>
            public string TitleBar { get; set; }

            /// <summary>Проценты</summary>
            private int _Percent = 0;

            public int Percent
            {
                get => _Percent;
                set => Set(ref _Percent, value);
            }
        }

        #endregion

        #region Прослушивания
        /// <summary>Прослушивания</summary>
        private int _CountPlay;

        public int CountPlay
        {
            get => _CountPlay;
            set => Set(ref _CountPlay, value);
        }
        #endregion

        #region Скачивания
        /// <summary>Скачивания</summary>
        private int _CountDownload;

        public int CountDownload
        {
            get => _CountDownload;
            set => Set(ref _CountDownload, value);
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
            _StatusBars = new ObservableCollection<StatusBarStruct>();

            FillSettings();
            FillCommand();

            LaunchAsync();
        }

        #endregion

        #region Helper

        private void FillSettings()
        {
            BestProxieSettings = SettingHelper.LoadSetting(new SettingsBestProxieViewModel());
            LocalProxySettings = SettingHelper.LoadSetting(new SettingsLocalProxyViewModel());
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
            try
            {
                MessageUpdate("Запуск...", OutLvl.Good);
                List<string> Proxy = await GetProxy();
                int CountProxy = Proxy.Count;
                MessageUpdate("Получено " + CountProxy + " прокси", CountProxy > 0 ? OutLvl.Good : OutLvl.Err);
                await Task.Run(async () => await RunBoost(Proxy));
                LaunchAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                mWindow.Close();
            }
        }

        private async Task RunBoost(List<string> Proxy)
        {
            IBoostSite BoostSite = GetBoostSite(Proxy);
            await BoostSite.LaunchBoostAsync();
        }

        private IBoostSite GetBoostSite(List<string> Proxy)
        {
            void delegateMsg(string msg) => MessageUpdate(msg);
            void delegateCountPlay(int countPlay) => App.Current.Dispatcher.Invoke(() => CountPlay = countPlay);
            void delegateCountDownload(int countDownload) => App.Current.Dispatcher.Invoke(() => CountDownload = countDownload);

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
                        UseProxyRepeat = OtherSettings.UseProxyRepeat,
                        OutMsgAct = delegateMsg,
                        CountDownloadAct = delegateCountDownload,
                        CountPlayAct = delegateCountPlay,
                        LinkList = MainSettings.ListLinkBoost.ToList(),
                        VisibleProcess = OtherSettings.ViewProcess
                    });
                case SiteList.SoundCloud:
                    return new SoundCloud(new SettingsSoundCloud()
                    {
                        CountStream = MainSettings.CountStream,
                        Mode = MainSettings.Mode.ToEnum<ModeList>(),
                        ProxyList = Proxy,
                        Pause = OtherSettings.Pause,
                        PercentPlay = OtherSettings.PlayTime,
                        UseProxyRepeat = OtherSettings.UseProxyRepeat,
                        OutMsgAct = delegateMsg,
                        CountDownloadAct = delegateCountDownload,
                        CountPlayAct = delegateCountPlay,
                        LinkList = MainSettings.ListLinkBoost.ToList(),
                        VisibleProcess = OtherSettings.ViewProcess
                    });
            }
            return null;
        }

        #region Proxy

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

            ClearStatusBars();

            return OutListProxy;
        }

        private List<IProxy> FillProxyContainer()
        {
            List<IProxy> proxyContainer = new List<IProxy>();
            Action<string> delegateMsg = (msg) => MessageUpdate(msg);            
            string urlSite = MainSettings.ListLinkBoost[0];

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

                StatusBarStruct StBr = CreateStatusBar("BestProxie");
                Action<int> delegateStatus = (status) => StBr.Percent = status;

                proxyContainer.Add(new BestProxie(urlSite, argsService, ref delegateMsg, ref delegateStatus));
            }

            if(LocalProxySettings.ListProxyFileItem.Count > 0)
            {
                StatusBarStruct StBr = CreateStatusBar("LocalProxy");
                Action<int> delegateStatus = (status) => StBr.Percent = status;

                proxyContainer.Add(new MyProxy(urlSite, LocalProxySettings.ListProxyFileItem.ToList(), ref delegateMsg, ref delegateStatus));
            }

            return proxyContainer;
        }

        #endregion

        #region StatusBar

        private StatusBarStruct CreateStatusBar(string name)
        {
            StatusBarStruct StBr = new StatusBarStruct()
            {
                TitleBar = name,
                Percent = 0
            };

            StatusBars.Add(StBr);

            return StBr;
        }

        private void ClearStatusBars()
        {
            StatusBars.Clear();
        }

        #endregion

        #region Msg

        private void MessageUpdate(string msg, OutLvl lvl = OutLvl.Info)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                msg = "[" + NowDate + "] " + msg;

                ListViewOutInfoItem.Add(new OutInformationStruct()
                {
                    ColorText = ColorLvl[lvl],
                    InformationText = msg
                });
                AddLog(msg, lvl);
            });
        }

        private static string NowDate => DateTime.Now.ToString("HH:mm:ss");

        private readonly Dictionary<OutLvl, SolidColorBrush> ColorLvl = new Dictionary<OutLvl, SolidColorBrush>
        {
            {OutLvl.Err, Brushes.Red},
            {OutLvl.Info, Brushes.Black},
            {OutLvl.Good, Brushes.Green}
        };

        #endregion

        #endregion
    }
}
