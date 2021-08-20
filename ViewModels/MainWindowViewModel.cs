using BoxBoost.Infrastructure.Commands;
using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BoxBoost.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Controls

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
        private string _Title = "test";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region Размер заголовка окна
        /// <summary>Заголовок</summary>
        private int _TitleGridLength = 42;

        public GridLength TitleGridLength
        {
            get => new GridLength(_TitleGridLength + ResizeBoreder);
        }
        #endregion

        #region Статус операции
        /// <summary> Статус операции </summary>
        private string _Status = "Ready";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion

        #region Видимость окна настроек
        /// <summary> Видимость окна настроек </summary>
        private bool _VisibleSettingWindow = false;

        public bool VisibleSettingWindow
        {
            get => _VisibleSettingWindow;
            set => Set(ref _VisibleSettingWindow, value);
        }
        #endregion

        #region Граница рамки для скругления углов

        /// <summary> Контрол окна </summary>
        private Window mWindow;        

        /// <summary> Размер рамки </summary>
        private int _ResizeBoreder = 6;

        public int ResizeBoreder
        {
            get => _ResizeBoreder;
            set => Set(ref _ResizeBoreder, value);
        }

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBoreder + OuterMagrinSize); } }

        /// <summary> Отступ для рамки </summary>
        private int _OuterMagrinSize = 10;

        public int OuterMagrinSize
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : _OuterMagrinSize;
            set => Set(ref _OuterMagrinSize, value);
        }

        public Thickness OuterMagrinSizeThickness { get { return new Thickness(OuterMagrinSize); } }

        /// <summary> Радиус скругления углов </summary>
        private int _WindowRadious = 10;

        public int WindowRadious
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : _WindowRadious;
            set => Set(ref _WindowRadious, value);
        }

        public CornerRadius WindowRadiousCorner { get { return new CornerRadius(WindowRadious); } }
        #endregion

        #endregion

        #region Команды

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
            mWindow.WindowState = WindowState.Maximized;
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
            SystemCommands.ShowSystemMenu(mWindow, GetMousePointion());
        }

        private bool CanMenuCommandExecute(object p) => true;

        #endregion

        #endregion

        public MainWindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMagrinSize));
                OnPropertyChanged(nameof(OuterMagrinSizeThickness));
                OnPropertyChanged(nameof(WindowRadious));
                OnPropertyChanged(nameof(WindowRadiousCorner));
            };

            #region Команды

            MinimizeCommand = new LambdaCommand(OnMinimizeCommandExecute, CanMinimizeCommandExecute);
            MaximizeCommand = new LambdaCommand(OnMaximizeCommandExecute, CanMaximizeCommandExecute);
            CloseCommand = new LambdaCommand(OnCloseCommandExecute, CanCloseCommandExecute);
            MenuCommand = new LambdaCommand(OnMenuCommandExecute, CanMenuCommandExecute);

            #endregion
        }

        #region Private Helpers

        private Point GetMousePointion()
        {
            Point position = Mouse.GetPosition(mWindow);
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion
    }
}
