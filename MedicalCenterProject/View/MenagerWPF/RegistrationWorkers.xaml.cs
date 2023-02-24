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

namespace MedicalCenterProject.View.MenagerWPF
{
    /// <summary>
    /// Interaction logic for RegistrationWorkers.xaml
    /// </summary>
    public partial class RegistrationWorkers : Window
    {
        private WorkersController workersController;
        public RegistrationWorkers()
        {
            InitializeComponent();
            var app = Application.Current as App;
            workersController = app.WorkersController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyFields())
            {
                WorkersDto newWorker = ProcessRequest();
                workersController.RegisterWorkers(newWorker);
            }
        }

        private WorkersDto ProcessRequest()
        {
            string name = nameTextbox.Text;
            string surname = surnameTextbox.Text;
            string email = emailTextbox.Text;
            string username = usernameTextbox.Text;
            string password = passwordBox.Password;
            string workplace = workplaceTextbox.Text;
            string shift = shiftTextbox.Text;

            return new WorkersDto(-1,name, surname, email, username, password, workplace, shift);
        }

        public bool CheckEmptyFields()
        {
            if (isNameFieldEmpty()) return false;
            if (isSurnameFieldEmpty()) return false;
            if (isEmailFieldEmpty()) return false;
            if (isUsernameFieldEmpty()) return false;
            if (isPasswordFieldEmpty()) return false;
            
            if (isWorkplaceFieldEmpty()) return false;
            if (isShiftFieldEmpty()) return false;
            return true;
        }

        public bool isWorkplaceFieldEmpty()
        {
            if(workplaceTextbox.Text == "")
            {
                MessageBox.Show("Workplace field cant be empty.");
                return true;
            }
            return false;
        }

        public bool isShiftFieldEmpty()
        {
            if (shiftTextbox.Text == "")
            {
                MessageBox.Show("Shift field cant be empty.");
                return true;
            }
            return false;
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

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Staff s = new Staff();
            s.Show();
            this.Close();
        }
    }
}
