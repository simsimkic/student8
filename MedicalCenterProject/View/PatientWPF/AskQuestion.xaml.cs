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
    /// Interaction logic for AskQuestion.xaml
    /// </summary>
    public partial class AskQuestion : Window
    {
        private FaqController faqController;
        public AskQuestion()
        {
            InitializeComponent();
            var app = Application.Current as App;
            faqController = app.FaqController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (askBox.Text == "") {
                MessageBox.Show("Field can't be empty");
            }
            else
            {
                FaqDto question = new FaqDto(askBox.Text, null);
                faqController.LeaveQuestion(question);
            }
            Patient pt = new Patient();
            this.Close();
            pt.Show();
            pt.patientIdTextBox.Text = patientIdTextbox.Text;
        }
    }
}
