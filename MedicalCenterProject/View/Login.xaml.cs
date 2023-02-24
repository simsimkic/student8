using Controller;
using MedicalCenterProject.Exceptions;
using MedicalCenterProject.View.MenagerWPF;
using System.Windows;
using MedicalCenterProject.View.SecretaryWPF;
using MedicalCenterProject.View.PatientWPF;
using MedicalCenterProject.View.DoctorWPF;

namespace MedicalCenterProject.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private readonly UserController userController;
        private readonly WorkersController workersController;
        private readonly NotificationController notificationController;
        private readonly PatientController patientController;

        public Login()
        {
            InitializeComponent();
            var app = Application.Current as App;
            userController = app.UserController;
            workersController = app.WorkersController;
            notificationController = app.NotificationController;
            patientController = app.PatientController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyFields())
            {
                int id = 0;
                int id1 = 0;
                 string role = userController.SignIn(usernameTextbox.Text, passwordBox.Password);
                if (role == "Doctor")
                {
                    id = workersController.GetUserId(usernameTextbox.Text, passwordBox.Password);
                }
                else if (role == "Patient")
                {
                    id1 = patientController.getPatientID(usernameTextbox.Text, passwordBox.Password);
                }
                 if (role.Contains("Wrong")) MessageBox.Show("Wrong username or password");
                 else RedirectUser(role,id,id1);          
            }
        }

        public bool CheckEmptyFields()
        {
            if (isUsernameFieldEmpty()) return false;
            if (isPasswordFieldEmpty()) return false;
            return true;
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

        public bool isUsernameFieldEmpty()
        {
            if (usernameTextbox.Text == "")
            {
                MessageBox.Show("Username field cant be empty.");
                return true;
            }
            return false;
        }

        public void RedirectUser(string role, int id, int id1)
        {
            if (role == "Patient") RedirectToPatient(id1);

            else if (role == "Secretary") RedirectToSecretary();

            else if (role == "Doctor") RedirectToDoctor(id);

            else RedirectToMenager();
        }

        private void RedirectToDoctor(int id)
        {
            Doctor doctor = new Doctor();
            doctor.doctorId.Text = id.ToString();
            this.Close();
            doctor.Show();
        }

        public void RedirectToMenager()
        {
            HomePage menager = new HomePage();
            this.Close();
            menager.Show();
        }

        public void RedirectToSecretary()
        {
            Secretary secretary = new Secretary();
            this.Close();
            secretary.Show();
        }

        public void RedirectToPatient(int id1)
        {
            Patient patient = new Patient();
            this.Close();
            patient.Show();

            patient.ID = id1.ToString();
            patient.patientIdTextBox.Text = id1.ToString();
            patient.Show();
        }
    }
}
