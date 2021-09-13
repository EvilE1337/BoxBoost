using BoxBoost.Infrastructure.Commands;
using BoxBoost.ViewModels.Base;
using BoxBoost.ViewModels.VMSettings;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace BoxBoost.ViewModels
{
    public class SettingsLocalProxyViewModel : LocalProxySettings
    {
        #region Controls

        #endregion

        #region Commands

        #region Открыть файл
        [XmlIgnore]
        public ICommand OpenFileCommand { get; set; }

        private void OnOpenFileCommandExecute(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = File.ReadAllText(openFileDialog.FileName).Split(stringSeparators, StringSplitOptions.None);

                foreach (string el in lines)
                {
                    if(!string.IsNullOrEmpty(el) && ListProxyFileItem.IndexOf(el) == -1)
                        ListProxyFileItem.Add(el);
                }
            }
        }

        private bool CanOpenFileCommandExecute(object p) => true;

        #endregion

        #region Очистить список
        [XmlIgnore]
        public ICommand ClearListCommand { get; set; }

        private void OnClearListCommandExecute(object p) => ListProxyFileItem.Clear();

        private bool CanClearListCommandExecute(object p) => true;

        #endregion

        #endregion

        #region constructor

        public SettingsLocalProxyViewModel()
        {
            ListProxyFileItem = new ObservableCollection<string>();

            #region команды
            OpenFileCommand = new LambdaCommand(OnOpenFileCommandExecute, CanOpenFileCommandExecute);
            ClearListCommand = new LambdaCommand(OnClearListCommandExecute, CanClearListCommandExecute);
            #endregion
        }

        #endregion
    }
}
