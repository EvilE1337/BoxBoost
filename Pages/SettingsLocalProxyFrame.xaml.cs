using BoxBoost.Infrastructure.Helpers;
using BoxBoost.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoxBoost.Pages
{
    /// <summary>
    /// Interaction logic for SettingsLocalProxyFrame.xaml
    /// </summary>
    public partial class SettingsLocalProxyFrame : BasePage<SettingsLocalProxyViewModel>
    {
        public SettingsLocalProxyFrame()
        {
            InitializeComponent();
            Loaded += LoadEvent;
            Unloaded += UnloadEvent;
        }

        private void LoadEvent(object sender, RoutedEventArgs e)
        {
            ViewModel = SettingHelper.LoadSetting(base.ViewModel);
        }

        private void UnloadEvent(object sender, RoutedEventArgs e)
        {
            SettingHelper.SaveSetting(base.ViewModel);
        }
    }
}
