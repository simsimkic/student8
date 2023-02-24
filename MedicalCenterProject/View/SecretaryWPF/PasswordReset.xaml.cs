using Controller;
using Model;
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

namespace MedicalCenterProject.View.SecretaryWPF
{
    /// <summary>
    /// Interaction logic for PasswordReset.xaml
    /// </summary>
    public partial class PasswordReset : Window
    {
        private UserController userController;
        public PasswordReset()
        {
            InitializeComponent();
            var app = Application.Current as App;
            userController = app.UserController;
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                string updatedPass = userController.ChangePassword(usernameTextbox.Text, newPasswordTextbox.Text);
                if (updatedPass == null) MessageBox.Show("That username doesnt exist");
            }
        }
        
        private bool Validate()
        {
            if(usernameTextbox.Text == "")
            {
                System.Windows.MessageBox.Show("Username field cant be empty");
                return false;
            }
            
            else if(newPasswordTextbox.Text == "")
            {
                System.Windows.MessageBox.Show("New password field cant be empty");
                return false;
            }
            else if(repeatedPasswordTextbox.Text == "")
            {
                System.Windows.MessageBox.Show("Repeated password field cant be empty");
                return false;
            }
            else if(newPasswordTextbox.Text != repeatedPasswordTextbox.Text)
            {
                System.Windows.MessageBox.Show("New password and repeated password fields are different");
                return false;
            }
            return true;
        }
    }
}
