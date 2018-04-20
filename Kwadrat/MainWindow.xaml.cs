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
                btnDraw.IsEnabled = true;
             //   txtBok.IsEnabled = false;             //blokuje wpisywanie wiecej niz 1 popranej cyfry
            }
            else
            {
                lblKomunikat.Foreground = Brushes.Red;
                lblKomunikat.Content = "Podaj poprawną wartość!!!";
                btnDraw.IsEnabled = false;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtBok.Clear();
          //  txtBok.IsEnabled = true;
            txtPole.Clear();                            //czyścić można tak
            txtOb.Text = String.Empty;                  //i tak
            kwadrat.Height = 0;
            kwadrat.Width = 0;
            btnDraw.IsEnabled = true;
            lblKomunikat.Foreground = Brushes.Black;
            lblKomunikat.Content = "Podaj wymiar boku";
        }


        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            if ((cmbKolorRamki.Text == String.Empty) || (cmbKolorWyp.Text == String.Empty))     //sprawdza czy ustawione są kolory ramki i wypełnienia
            {
                btnDraw.IsEnabled = false;
                lblKomunikat.Foreground = Brushes.Red;
                lblKomunikat.Content = "Podaj kolory wypełnienia i ramki";
                btnDraw.IsEnabled = false;                                                      //jeżeli brak kolorów przycisk jest blokowany
                return;
            }
            else
                btnDraw.IsEnabled = true;

            double bok = double.Parse(txtBok.Text);
            if (bok <= 300)                                                                      //sprawdza czy bok ma właściwy rozmiar
            {
                kwadrat.Height = bok;
                kwadrat.Width = bok;
                SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFromString(cmbKolorRamki.Text);
                kwadrat.Stroke = color;
                kwadrat.StrokeThickness = bok / 20;
                color = (SolidColorBrush)new BrushConverter().ConvertFromString(cmbKolorWyp.Text);
                kwadrat.Fill = color;
                kwadrat.Opacity = (cbPrzezroczysty.IsChecked.Value) ? 0.5 : 1;
            }
            else
            {
                lblKomunikat.Foreground = Brushes.Red;
                lblKomunikat.Content = "Podany kwadrat jest za duży";
                btnDraw.IsEnabled = false;
            }
        }

        private void rbtnUkryj_Checked(object sender, RoutedEventArgs e)
        {
            kwadrat.Visibility = Visibility.Hidden;
       //     rbtnPokaz.IsChecked = false;
        }

        private void rbtnPokaz_Checked(object sender, RoutedEventArgs e)
        {
            kwadrat.Visibility = Visibility.Visible;
       //     rbtnUkryj.IsChecked = false;
        }
    }
}
