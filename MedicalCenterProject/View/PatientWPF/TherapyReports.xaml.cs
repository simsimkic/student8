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

namespace MedicalCenterProject.View.PatientWPF
{
    /// <summary>
    /// Interaction logic for TherapyReports.xaml
    /// </summary>
    public partial class TherapyReports : Window
    {
        public TherapyReports()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patient pt = new Patient();
            this.Close();
            pt.Show();
        }
    }
}
