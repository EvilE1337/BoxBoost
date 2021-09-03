using BoxBoost.DataModels;
using BoxBoost.Infrastructure.Commands;
using BoxBoost.Infrastructure.Helpers;
using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BoxBoost.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Controls

        #region Коллекция для кнопок пагинации

        private ObservableCollection<ButtonPaginationStruct> _ButtonsPagination;

        public ObservableCollection<ButtonPaginationStruct> ButtonsPagination
        {
            get => _ButtonsPagination;
            set => Set(ref _ButtonsPagination, value);
        }

        public class ButtonPaginationStruct : ViewModel
        {
            /// <summary>Подсказка</summary>
            public string DataTitle { get; set; }

            /// <summary>Команда</summary>
            public ICommand Command { get; set; }

            private bool _IsChecked;
            /// <summary>Картинка</summary>
            public bool IsChecked
            {
                get => _IsChecked;
                set => Set(ref _IsChecked, value);
            }
        }

        #endregion

        #region Активная страница
        /// <summary>Активная страница</summary>
        private ApplicationPage _CurrentPage = ApplicationPage.None;

        public ApplicationPage CurrentPage
        {
            get => _CurrentPage;
            set
            {
                Set(ref _CurrentPage, value);
                ButtonsPagination[(int)value].IsChecked = true;
            }
        }
        #endregion

        #region Минимальный длинна окна
        /// <summary>Заголовок</summary>
        private double _WindowMinimumHeight = 400;

        public double WindowMinimumHeight
        {
            get => _WindowMinimumHeight;
            set => Set(ref _WindowMinimumHeight, value);
        }
        #endregion

        #region Минимальная ширина окна
        /// <summary>Заголовок</summary>
        private double _WindowMinimumWidth = 400;

        public double WindowMinimumWidth
        {
            get => _WindowMinimumWidth;
            set => Set(ref _WindowMinimumWidth, value);
        }
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

        #region Размер заголовка окна
        /// <summary>Размер заголовка</summary>
        private readonly int _TitleHeight = 42;

        public GridLength TitleHeightGridLength => new GridLength(_TitleHeight + ResizeBoreder);
        #endregion

        #region Размер подвала окна
        /// <summary>Размер подвала</summary>
        private readonly int _StatusHeight = 42;

        public GridLength StatusHeightGridLength => new GridLength(_StatusHeight - ResizeBoreder);
        #endregion
        
        #region Последнее известное положение окна
        /// <summary> Видимость окна настроек </summary>
        private WindowDockPosition _DockPosition = WindowDockPosition.Undocked;

        public WindowDockPosition DockPosition
        {
            get => _DockPosition;
            set => Set(ref _DockPosition, value);
        }
        #endregion

        #region Рамка окна

        /// <summary> Контрол окна </summary>
        private Window mWindow;

        /// <summary> Если окно развернуто или закреплено должно ли быть без полей </summary>
        public bool Borderless { get { return (mWindow.WindowState == WindowState.Maximized || DockPosition != WindowDockPosition.Undocked); } }

        /// <summary> Размер рамки </summary>
        private int _ResizeBoreder = 6;

        public int ResizeBoreder
        {
            get => _ResizeBoreder;
            set => Set(ref _ResizeBoreder, value);
        }

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBoreder + OuterMarginSize); } }

        public Thickness InnerContentPadding { get { return new Thickness(ResizeBoreder); } }

        /// <summary> Отступ для рамки </summary>
        private int _OuterMarginSize = 10;

        public int OuterMarginSize
        {
            get => Borderless ? 0 : _OuterMarginSize;
            set => Set(ref _OuterMarginSize, value);
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary> Радиус скругления углов </summary>
        private int _WindowRadius = 10;

        public int WindowRadius
        {
            get => Borderless ? 0 : _WindowRadius;
            set => Set(ref _WindowRadius, value);
        }

        public CornerRadius WindowRadiusCorner { get { return new CornerRadius(WindowRadius); } }
        #endregion

        #endregion

        #region Commands

        #region Уменьшение окна

        public ICommand MinimizeCommand { get; set; }

        private void OnMinimizeCommandExecute(object p)
        {
            mWindow.WindowState = WindowState.Minimized;
        }

        private bool CanMinimizeCommandExecute(object p) => true;

        #endregion

        #region Увеличение окна

        public ICommand MaximizeCommand { get; set; }

        private void OnMaximizeCommandExecute(object p)
        {
            mWindow.WindowState ^= WindowState.Maximized;
        }

        private bool CanMaximizeCommandExecute(object p) => true;

        #endregion

        #region Закрытие окна

        public ICommand CloseCommand { get; set; }

        private void OnCloseCommandExecute(object p)
        {
            mWindow.Close();
        }

        private bool CanCloseCommandExecute(object p) => true;

        #endregion

        #region Отображение меню окна

        public ICommand MenuCommand { get; set; }

        private void OnMenuCommandExecute(object p)
        {
            SystemCommands.ShowSystemMenu(mWindow, WindowHelper.GetMousePointion(mWindow));
        }

        private bool CanMenuCommandExecute(object p) => true;

        #endregion

        #region Смена страницы >

        public ICommand SwitchRightCommand { get; set; }

        private void OnSwitchRightCommandExecute(object p)
        {
            SwitchPage(false);
        }

        private bool CanSwitchRightCommandExecute(object p) => true;

        #endregion

        #region Смена страницы <

        public ICommand SwitchLeftCommand { get; set; }

        private void OnSwitchLeftCommandExecute(object p)
        {
            SwitchPage(true);
        }
        
        private bool CanSwitchLeftCommandExecute(object p) => true;

        #endregion

        #region Запуск (открытие нового окна)

        public ICommand StartBoostCommand { get; set; }

        private void OnStartBoostCommandExecute(object p)
        {
            _WindowStorage.OpenWindow(ApplicationWindow.BoostWin);
        }

        private bool CanStartBoostCommandExecute(object p) => true;

        #endregion

        #endregion

        #region Constructor

        public MainWindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                WindowResized();
            };

            _WindowStorage = new WindowStorage();
            PaginationInitialize();

            #region Команды

            #region Системные

            MinimizeCommand = new LambdaCommand(OnMinimizeCommandExecute, CanMinimizeCommandExecute);
            MaximizeCommand = new LambdaCommand(OnMaximizeCommandExecute, CanMaximizeCommandExecute);
            CloseCommand = new LambdaCommand(OnCloseCommandExecute, CanCloseCommandExecute);
            MenuCommand = new LambdaCommand(OnMenuCommandExecute, CanMenuCommandExecute);

            #endregion

            SwitchRightCommand = new LambdaCommand(OnSwitchRightCommandExecute, CanSwitchRightCommandExecute);
            SwitchLeftCommand = new LambdaCommand(OnSwitchLeftCommandExecute, CanSwitchLeftCommandExecute);
            StartBoostCommand = new LambdaCommand(OnStartBoostCommandExecute, CanStartBoostCommandExecute);

            #endregion

            // Правка для изменение размеров окна
            var resizer = new WindowResizer(mWindow);

            resizer.WindowDockChanged += (dock) =>
            {
                //сохраняем позицию окна
                DockPosition = dock;

                //вызываем событие изменения окна
                WindowResized();
            };
        }

        #endregion

        #region Private Helpers

        private WindowStorage _WindowStorage;

        private async void SwitchPage(bool isBack)
        {
            int newCurrentPage = (int)CurrentPage + (isBack ? -1 : 1);
            int countPage = Enum.GetNames(typeof(ApplicationPage)).Length;
            if (newCurrentPage >= 0 && newCurrentPage < countPage)
            {
                await PageStorage.BeforeUnloadPage(isBack);
                CurrentPage = (ApplicationPage)newCurrentPage;
            }
        }

        private async void SwitchPage(ApplicationPage page)
        {
            bool isBack = CurrentPage > page;
            await PageStorage.BeforeUnloadPage(isBack);
            CurrentPage = page;
        }

        private void PaginationInitialize()
        {
            ButtonsPagination = new ObservableCollection<ButtonPaginationStruct>();

            System.Enum.GetNames(typeof(ApplicationPage))
                .ToList().ForEach(f =>
                {
                    void Act(object obj) => SwitchPage((ApplicationPage)System.Enum.Parse(typeof(ApplicationPage), f));

                    ButtonsPagination.Add(new ButtonPaginationStruct()
                    {
                        IsChecked = false,
                        DataTitle = f,
                        Command = new LambdaCommand(Act, (object obj) => true)
                    });
                });

            CurrentPage = ApplicationPage.None;
        }

        private void WindowResized()
        {
            // События изменения окна
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowRadiusCorner));
        }

        #endregion
    }
}
