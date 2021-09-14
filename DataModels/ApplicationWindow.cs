using BoxBoost.ValueConverters;
using BoxBoost.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoxBoost.DataModels
{
    internal class WindowStorage
    {
        List<Window> WindowSa = new List<Window>();

        public WindowStorage()
        {
            CheckWindow();
        }

        private async void CheckWindow()
        {
            while (true)
            {
                for (int i = 0; i < WindowSa.Count; i++)
                    if (!WindowSa[i].IsLoaded)
                        RemoveWindow(i);
                await Task.Delay(5000);
            }
        }

        internal void OpenWindow(ApplicationWindow appWindow)
        {
            Window _window = Create(appWindow);
            _window.Show();
            AddWindow(_window);
        }

        internal void OpenWindow(ApplicationWindow appWindow, out Window _window)
        {
            _window = Create(appWindow);
            _window.Show();
            AddWindow(_window);
        }

        internal void CloseWindow(Window _Window)
        {
            
        }

        private Window Create(ApplicationWindow appWindow) => (Window)new ApplicationWindowValueConverter().Convert(appWindow);

        private void AddWindow(Window newWindow) => WindowSa.Add(newWindow);

        private void RemoveWindow(int index)
        {
            if(WindowSa[index] != null)
                WindowSa.RemoveAt(index);
        }

        private void RemoveWindowAll() => WindowSa = null;

        private void CloseIt(int index)
        {
            if (WindowSa[index] != null)
                WindowSa[index].Close();
        }

        private void CloseAll() => WindowSa.ForEach(f => f.Close());
        
    }

    public enum ApplicationWindow
    {
        None = 0,
        MainWin = 1,
        BoostWin = 2,
    }
}
