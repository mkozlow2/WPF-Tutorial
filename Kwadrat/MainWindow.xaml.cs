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

namespace Kwadrat
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

        private void txtBok_TextChanged(object sender, TextChangedEventArgs e)
        {
            double bok;
            if (double.TryParse(txtBok.Text, out bok) && bok >= 0)
            {
                txtPole.Text = Math.Pow(bok, 2.0).ToString();
                txtOb.Text = (bok * 4).ToString();
                lblKomunikat.Content = String.Empty;
                txtBok.IsEnabled = false;
            }
            else
            {
                lblKomunikat.Foreground = Brushes.Red;
                lblKomunikat.Content = "Podaj poprawną wartość!!!";
            } 
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtBok.Clear();
            txtBok.IsEnabled = true;
            txtPole.Clear();                            //można tak
            txtOb.Text = String.Empty;                  //i tak
            lblKomunikat.Foreground = Brushes.Black;
            lblKomunikat.Content = "Podaj wymiar boku";
        }
    }
}
