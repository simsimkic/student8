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

namespace MedicalCenterProject.View.SecretaryWPF
{
    /// <summary>
    /// Interaction logic for RegisterPatient.xaml
    /// </summary>
    public partial class RegisterPatient : Window
    {

        private UserController userController;
        public RegisterPatient()
        {
            InitializeComponent();
            var app = Application.Current as App;
            userController = app.UserController;
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

        public UserDto ProcessUserRequest()
        {
            string name = nameTextbox.Text;
            string surname = surnameTextbox.Text;
            string email = emailTextbox.Text;
            string username = usernameTextbox.Text;
            string password = passwordBox.Password;
            string jmbg = PatientJmbgTextbox.Text;
            return new UserDto(name, surname, email, username, password, "Patient", jmbg);
        }

        public bool CheckEmptyFields()
        {
            if (isNameFieldEmpty()) return false;
            if (isSurnameFieldEmpty()) return false;
            if (isEmailFieldEmpty()) return false;
            if (isUsernameFieldEmpty()) return false;
            if (isPasswordFieldEmpty()) return false;
            if (isJmbgFieldEmpty()) return false;
            return true;
        }

        public bool isNameFieldEmpty()
        {
            if (nameTextbox.Text == "")
            {
                MessageBox.Show("Name field cant be empty.");
                return true;
            }
            return false;
        }

        public bool isSurnameFieldEmpty()
        {
            if (surnameTextbox.Text == "")
            {
                MessageBox.Show("Surname field cant be empty.");
                return true;
            }
            return false;
        }

        public bool isEmailFieldEmpty()
        {
            if (emailTextbox.Text == "")
            {
                MessageBox.Show("Email field cant be empty.");
                return true;
            }
            return false;
        }

        public bool isUsernameFieldEmpty()
        {
            if (usernameTextbox.Text == "")
            {
                MessageBox.Show("Username field cant be empty.");
                return true;
            }
            return false;
        }

        public bool isJmbgFieldEmpty()
        {
            if (PatientJmbgTextbox.Text == "")
            {
                MessageBox.Show("JMBG field cant be empty.");
                return true;
            }
            return false;
        }

        public bool isPasswordFieldEmpty()
        {
            if (passwordBox.Password == "")
            {
                MessageBox.Show("Password field cant be empty.");
                return true;
            }
            return false;
        }

        public bool FrontEmailValidation()
        {
            if (!emailTextbox.Text.Contains("@"))
            {
                MessageBox.Show("Email must contain '@' ! ");
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyFields() && FrontEmailValidation())
            {
                
                UserDto newUser = ProcessUserRequest();
                if (userController.RegisterUser(newUser) == null) MessageBox.Show("Wrong username or email.");
                else MessageBox.Show("User registered.");
            }
        }
    }
}
