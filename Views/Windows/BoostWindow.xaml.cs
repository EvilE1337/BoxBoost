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
using System.Windows.Shapes;

namespace BoxBoost
{
    /// <summary>
    /// Interaction logic for BoostWindow.xaml
    /// </summary>
    public partial class BoostWindow : Window
    {
        public BoostWindow()
        {
            InitializeComponent();
            this.DataContext = new BoostWindowViewModel(this);          
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
