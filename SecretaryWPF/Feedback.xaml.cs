using Controller;
using MedicalCenterProject.Dtos;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Input;

namespace MedicalCenterProject.View.SecretaryWPF
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Window
    {
        public Feedback()
        {     
            InitializeComponent();
            var app = Application.Current as App;
            feedbackController = app.FeedbackController;
            FeedbackContentTextBox.Focus();
        }

        FeedbackController feedbackController;

        private void FeedbackSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFeedbackContent())
            {
                feedbackController.LeaveFeedback(ProcessFeedbackRequest());
                MessageBox.Show("Thanks for giving feedback ! ");
            }
        }

        public FeedbackDto ProcessFeedbackRequest()
        {
            string content = FeedbackContentTextBox.Text;
            return new FeedbackDto( -1 , content);
        }

        public bool ValidateFeedbackContent()
        {
            if(FeedbackContentTextBox.Text == "")
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
                this.Close();
                Secretary s = new Secretary();
                s.Show();
                s.examination.Focus();
            }
        }

        private void FeedbackContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Keyboard.ClearFocus();  
        }
    }
}
