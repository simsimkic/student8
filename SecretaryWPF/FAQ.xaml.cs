using Controller;
using MedicalCenterProject.Dtos;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalCenterProject.View.SecretaryWPF
{
    /// <summary>
    /// Interaction logic for FAQ.xaml
    /// </summary>
    public partial class FAQ : Window
    {
        public FaqController faqController;
        public FAQ()
        {
            InitializeComponent();
            var app = Application.Current as App;
            faqController = app.FaqController;
            QuestionListReview.Focus();
        }

        private void Questions_Click(object sender, RoutedEventArgs e)
        {
            List<FaqDto> allFAQ = faqController.GetUnansweredQuestions();
            ConfigureWPF();
            ProcessFaqToWpf(allFAQ);
            QuestionList.IsDropDownOpen = true;
            QuestionList.Focus();
        }

        private void ConfigureWPF()
        {
            QuestionList.IsEnabled = true;
            QuestionListReview.IsEnabled = false;
        }

       

        private void SubmitFaq_Click(object sender, RoutedEventArgs e)
        {
            FaqDto faq = ProcessFaqRequest();
            faqController.AddFAQ(faq);
            QuestionList.Items.Clear();
            MessageBox.Show("Successfully added.");
            QuestionListReview.Focus();
        }

        private FaqDto ProcessFaqRequest()
        {
            string answer = TextboxAnswer.Text;
            List<FaqDto> allFAQ = faqController.GetUnansweredQuestions();
            
            string question = allFAQ[QuestionList.SelectedIndex].Question;
            return new FaqDto(question, answer);
        }

        private void ProcessFaqToWpf(List<FaqDto> questions)
        {
            foreach (FaqDto question in questions) {
                QuestionList.Items.Add(question.Question);
            }
        }

        private void ConfigureWpfBeforeSubmitingAnswer()
        {
            
            Question.Content = QuestionList.SelectedItem;
            Question.Visibility = Visibility.Visible;
       
            labelAnswer.Visibility = Visibility.Visible;
            TextboxAnswer.Visibility = Visibility.Visible;
            SubmitFaq.Visibility = Visibility.Visible;
        }

        private void ConfigureWpfAfterSubmitingAnswer()
        {
            ConfigureVisibilityAfterSubmitingAnswer();
            ConfigureIsEnabledAfterSubmitingAnswer();
           
        }

        public void ConfigureVisibilityAfterSubmitingAnswer()
        {
            
            labelAnswer.Visibility = Visibility.Collapsed;
            TextboxAnswer.Visibility = Visibility.Collapsed;
            SubmitFaq.Visibility = Visibility.Collapsed;
            Question.Visibility = Visibility.Collapsed;
            
        }

        private void ConfigureIsEnabledAfterSubmitingAnswer()
        {
            QuestionList.IsEnabled = false;
            QuestionListReview.IsEnabled = true;
           
        }

        private void QuestionList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (QuestionList.SelectedIndex != -1) ConfigureWpfBeforeSubmitingAnswer();
            else ConfigureWpfAfterSubmitingAnswer(); 
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
    }
}
