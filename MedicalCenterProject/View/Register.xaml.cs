using Controller;
using MedicalCenterProject.Exceptions;
using System.Windows;
using MedicalCenterProject.Dtos;

namespace MedicalCenterProject.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Register : Window
    {

        private readonly UserController userController;
        public Register()
        {
            InitializeComponent();
            var app = Application.Current as App;
            userController = app.UserController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyFields() && FrontEmailValidation())
            {
                UserDto newUser = ProcessUserRequest();
                if (userController.RegisterUser(newUser) == null) MessageBox.Show("Email or Username already exist.");
                else
                {
                    Login log = new Login();
                    this.Close();
                    log.Show();
                }
            }   
        }
        
        
        
        public UserDto ProcessUserRequest()
        {         
                string name = nameTextbox.Text;
                string surname = surnameTextbox.Text;
                string email = emailTextbox.Text;
                string username = usernameTextbox.Text;
                string password = passwordBox.Password;
                string jmbg = jmbgTextbox.Text;
                return new UserDto(name, surname, email, username, password,"Patient",jmbg);
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

        public bool isJmbgFieldEmpty()
        {
            if (jmbgTextbox.Text == "")
            {
                MessageBox.Show("Jmbg field cant be empty.");
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
    }
}
