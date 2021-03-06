﻿using System;
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
using System.Collections.ObjectModel;       //potrzebne do kolekcji ObservableCollection<T>
using System.ComponentModel;                //potrzbene do sortowania

namespace Lista_Produktow
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ObservableCollection<Produkt> ListaProduktow = null;    //pole typu lista (kolekcja) ObservableCollection<T>
        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }
        private void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();   //inicjalizacja listy (kolekcji) ObservableCollection<T>
            ListaProduktow.Add(new Produkt("MA-01", "miotła", 25, "Galeria Mokotów"));
            ListaProduktow.Add(new Produkt("GK-10", "garnek", 170, "Arkadia"));
            ListaProduktow.Add(new Produkt("DM-11", "duża miska", 127, "Galeria Mokotów"));
            ListaProduktow.Add(new Produkt("ZK-20", "zmywak", 1861, "CH Janki"));
            lstProdukty.ItemsSource = ListaProduktow;               //ItemSource umożliwia wiązanie kolekcji
            CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource);        //odczytanie niejawnego widoku 'wiązania z kolekcją' i przypisanie do obiektu widok
            widok.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));                    //odczytany widok zostaje rozszerzony o możliwość sortowania względem wybranej kolumny
            widok.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Ascending));                      //sortowanie malejace - Descending
            widok.Filter = FiltrUzytkownika;
        }
        private bool FiltrUzytkownika(object item)
        {
            if (String.IsNullOrEmpty(txtFiltr.Text))
                return true;
            else
                return ((item as Produkt).Nazwa.IndexOf(txtFiltr.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource).Refresh();
        }

        private void lstProdukty_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window1 okno1 = new Window1(this);
            okno1.ShowDialog();
        }

        private void Usuń_Click(object sender, RoutedEventArgs e)
        {
            Produkt produktZListy = lstProdukty.SelectedItem as Produkt;
            MessageBoxResult odpowiedz = MessageBox.Show("Czy wykasować produkt: " + produktZListy.ToString() + "?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (odpowiedz == MessageBoxResult.Yes)
                ListaProduktow.Remove(produktZListy);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window1 okno1 = new Window1(this, true);
            okno1.ShowDialog();
        }
    }
}
