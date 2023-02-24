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
    /// Interaction logic for SendFeedback.xaml
    /// </summary>
    public partial class SendFeedback : Window
    {
        public SendFeedback()
        {
            InitializeComponent();
            var app = Application.Current as App;
            feedbackController = app.FeedbackController;
            feedbackBox.Focus();
        }
        FeedbackController feedbackController;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFeedbackContent())
            {
                feedbackController.LeaveFeedback(ProcessFeedbackRequest());
                MessageBox.Show("Thanks for giving feedback ! ");
            }
            Patient pt = new Patient();
            pt.patientIdTextBox.Text = patientIdTextBox.Text;
            this.Close();
            pt.Show();
        }
        public FeedbackDto ProcessFeedbackRequest()
        {
            string content = feedbackBox.Text;
            return new FeedbackDto(-1, content);
        }

        public bool ValidateFeedbackContent()
        {
            if (feedbackBox.Text == "")
            {
                MessageBox.Show("You must write some text in box.");
                return false;
            }
            return true;
        }
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Keyboard.ClearFocus();
                
            }
        }

        private void FeedbackContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Keyboard.ClearFocus();
        }
    }
}
