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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for uSPJESNO_lijek.xaml
    /// </summary>
    public partial class uSPJESNO_lijek : Window
    {
        public uSPJESNO_lijek()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajLijek1 d = new DodajLijek1();
            d.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OSOBLJE o = new OSOBLJE();
            o.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Lekovi1 l = new Lekovi1();
            l.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Pocetna_strana p = new Pocetna_strana();
            p.Show();
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

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            DodajLijek1 l = new DodajLijek1();
            l.Show();
            this.Close();
        }
    }
}
