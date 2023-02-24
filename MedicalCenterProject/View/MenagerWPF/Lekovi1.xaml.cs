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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Lekovi1.xaml
    /// </summary>
    public partial class Lekovi1 : Window
    {
        public Lekovi1()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OSOBLJE p = new OSOBLJE();
            p.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Lekovi1 l = new Lekovi1();
            l.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Prostorije p = new Prostorije();
            p.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Broj_lekova b = new Broj_lekova();
            b.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Pocetna_strana p = new Pocetna_strana();
            p.Show();
            this.Close();
        }
    }
}
