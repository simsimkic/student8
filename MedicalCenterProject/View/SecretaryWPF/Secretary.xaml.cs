using MaterialDesignColors.Recommended;
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
using System.Xml;

namespace MedicalCenterProject.View.SecretaryWPF
{
    /// <summary>
    /// Interaction logic for Secretary.xaml
    /// </summary>
    public partial class Secretary : Window
    {
        public Secretary()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Feedback_Click_1(object sender, RoutedEventArgs e)
        {
            Feedback fb = new Feedback();
            fb.Show();
           
        }

        private void examination_Click(object sender, RoutedEventArgs e)
        {
            Examination ex = new Examination();
            ex.Show();
        }

        private void faq_Click(object sender, RoutedEventArgs e)
        {
            FAQ f = new FAQ();
            f.Show();
        }

        private void rooms_Click(object sender, RoutedEventArgs e)
        {
            Rooms r = new Rooms();
            r.Show();
        }

        

        private void registerPatient_Click(object sender, RoutedEventArgs e)
        {
            registerPatient.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(Feedback);
        }

        private void examination_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            examination.BorderThickness = new Thickness(0);
           
            examination.BorderBrush = Brushes.White;
        }

        private void examination_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
            examination.BorderBrush = Brushes.Gray;
            examination.BorderThickness = new Thickness(5);
           
        }
        private void Feedback_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(examination);
        }

        private void Feedback_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Feedback.BorderBrush = Brushes.Gray;
            Feedback.BorderThickness = new Thickness(7);
            
        }

        private void Feedback_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Feedback.BorderThickness = new Thickness(0);
           
            Feedback.BorderBrush = Brushes.White;
        }

        private void examination_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(changeDate);
        }
        private void changeDate_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            changeDate.BorderThickness = new Thickness(0);
           
            changeDate.BorderBrush = Brushes.White;
        }

        private void changeDate_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            changeDate.BorderBrush = Brushes.Gray;
            changeDate.BorderThickness = new Thickness(7);
           
        }

        private void changeRoom_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(changeRoom);
        }
        private void changeRoom_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            changeRoom.BorderBrush = Brushes.Gray;
            changeRoom.BorderThickness = new Thickness(7);
            
        }
        private void changeRoom_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            changeRoom.BorderThickness = new Thickness(0);
            
            changeRoom.BorderBrush = Brushes.White;
        }

        private void faq_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(rooms);
        }
        private void faq_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            faq.BorderThickness = new Thickness(0);
            
            faq.BorderBrush = Brushes.White;
        }

        private void faq_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            faq.BorderBrush = Brushes.Gray;
            faq.BorderThickness = new Thickness(7);
           
        }

        private void rooms_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(registerPatient);
        }

        private void rooms_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            rooms.BorderBrush = Brushes.Gray;
            rooms.BorderThickness = new Thickness(7);
        }

        private void rooms_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            rooms.BorderThickness = new Thickness(0);
            rooms.BorderBrush = Brushes.White;
        }

        private void registerPatient_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            registerPatient.BorderThickness = new Thickness(0);
            registerPatient.BorderBrush = Brushes.White;
        }

        private void registerPatient_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(tutorial);
        }

        private void registerPatient_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            registerPatient.BorderBrush = Brushes.Gray;
            registerPatient.BorderThickness = new Thickness(7);
            
        }

        private void tutorial_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tutorial.BorderBrush = Brushes.Gray;
            tutorial.BorderThickness = new Thickness(7);
           
        }

        private void tutorial_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(Feedback);
        }

        private void tutorial_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tutorial.BorderThickness = new Thickness(0);
            tutorial.BorderBrush = Brushes.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            this.Close();
            log.Show();
            log.usernameTextbox.Focus();
            
        }

        private void registerPatient_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterPatient reg = new RegisterPatient();
            reg.Show();
            reg.nameTextbox.Focus();
        }

        private void changeDate_Click(object sender, RoutedEventArgs e)
        {
            ChangeDate cd = new ChangeDate();
            cd.Show();
        }

        private void changeRoom_Click(object sender, RoutedEventArgs e)
        {
            ChangeRoom cr = new ChangeRoom();
            cr.Show();
        }

        private void tutorial_Click(object sender, RoutedEventArgs e)
        {
            Tutorial t = new Tutorial();
            t.Show();
        }

        private void CancelExam_Click(object sender, RoutedEventArgs e)
        {
            CancelExamination c = new CancelExamination();
            c.Show();
        }

        private void EmergencyExam_Click(object sender, RoutedEventArgs e)
        {
            //EmergencyExamination ee = new EmergencyExamination();
            //ee.Show();
        }

        private void EmergencyExam_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            EmergencyExam.BorderBrush = Brushes.Gray;
            EmergencyExam.BorderThickness = new Thickness(7);
           
        }

        private void EmergencyExam_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            EmergencyExam.BorderThickness = new Thickness(0);
            
            EmergencyExam.BorderBrush = Brushes.White;
        }

        private void CancelExam_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            CancelExam.BorderThickness = new Thickness(0);
           
            CancelExam.BorderBrush = Brushes.White;
        }

        private void CancelExam_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            CancelExam.BorderBrush = Brushes.Gray;
            CancelExam.BorderThickness = new Thickness(7);
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PasswordReset pr = new PasswordReset();
            pr.Show();
            pr.usernameTextbox.Focus();
        }
    }
}
