using Controller;
using MedicalCenterProject.Dtos;
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
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        private readonly PatientController patientController;
        public string ID;

        public Patient()
        {
            InitializeComponent();
            var app = Application.Current as App;
            patientController = app.PatientController;
            patientIdTextBox.Text = ID;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SendFeedback sd = new SendFeedback();
            
            sd.Show();
            sd.patientIdTextBox.Text = this.patientIdTextBox.Text;
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AskQuestion aq = new AskQuestion();
            aq.Show();
            aq.patientIdTextbox.Text = this.patientIdTextBox.Text;
            this.Close();

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Account ac = new Account();
            ac.Show();
            ac.patientIdTextBox.Text = this.patientIdTextBox.Text;
            this.Close();
            PatientDto patient = patientController.PatientInfo1(patientIdTextBox.Text);
            ac.name.Text = patient.Name.ToString();
            ac.surname.Text = patient.Surname.ToString();
            ac.eMailBox.Text = patient.Email.ToString();
            ac.usernameBox.Text = patient.Username.ToString();
            ac.jmbgBox.Text = patient.Jmbg.ToString();
            ac.patientIdTextBox.Text = patient.ID.ToString();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Login lg6 = new Login();
            this.Close();
            lg6.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            ScheduleExamination se = new ScheduleExamination();
            se.patientIdTextBox.Text = this.patientIdTextBox.Text;
            this.Close();
            se.Show();
            
            
        }

       

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            TherapyReports tr = new TherapyReports();
            tr.patientIdTextBox.Text = this.patientIdTextBox.Text;
            this.Close();
            tr.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Help hp = new Help();
            hp.patientIdTextBox.Text = this.patientIdTextBox.Text;
            this.Close();
            hp.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
