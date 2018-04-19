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

namespace Troll
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dobra decyzja!");
            Close();
        }

        private void btnY_MouseEnter(object sender, MouseEventArgs e)
        {
            var tmpMargin = btnY.Margin;
            btnY.Margin = btnN.Margin;
            btnN.Margin = tmpMargin;
        }
    }
}
