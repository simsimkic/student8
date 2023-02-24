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
using Controller;
using MedicalCenterProject.Dtos;
using Model;

namespace MedicalCenterProject.View.MenagerWPF
{
    /// <summary>
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class Staff : Window
    {
        private readonly WorkersController workersController;
        public Staff()
        {
            InitializeComponent();
            var app = Application.Current as App;
            workersController = app.WorkersController;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Specialist s = new Specialist();
            s.Show();
            this.Close();
            List<WorkersDto> Workers = workersController.GetWorkers();
            
            for (int i =0; i < Workers.Count; i++)
            {
                s.WorkersList.Items.Add(new WorkersDto() {Name= Workers[i].Name, Surname = Workers[i].Surname, Workplace=Workers[i].Workplace });
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWorkers r = new RegistrationWorkers();
            r.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }
    }
}
