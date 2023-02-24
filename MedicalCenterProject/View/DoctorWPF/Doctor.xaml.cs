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

namespace MedicalCenterProject.View.DoctorWPF
{
    /// <summary>
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {

        private readonly PatientController patientController;
        private readonly WorkersController workersController;
        private readonly ExaminationController examinationController;
        private readonly NotificationController notificationController;
        private readonly MedicineController medicineController;

        public Doctor()
        {
            InitializeComponent();
            var app = Application.Current as App;
            patientController = app.PatientController;
            workersController = app.WorkersController;
            examinationController = app.ExaminationController;
            notificationController = app.NotificationController;
            medicineController = app.MedicineController;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Doctor d = new Doctor();
            d.doctorId.Text = doctorId.Text;
            this.Close();
            d.Show();
        }

        private void ListPatient_Click(object sender, RoutedEventArgs e)
        {
            ListPatient l = new ListPatient();
            List<PatientDto> p = patientController.GetAllPatients();
            this.Close();
            l.Show();
            l.doctorId.Text = doctorId.Text;
            for (int i = 0; i < p.Count; i++)
            {
                l.lvUsers.Items.Add(new PatientDto() { Name = p[i].Name, Surname = p[i].Surname, Jmbg = p[i].Jmbg });
            }
        }

        private void CalendarExamination_Click(object sender, RoutedEventArgs e)
        {
            CalendarExamination c = new CalendarExamination();
            List<ExaminationDto> examination = examinationController.ListOfScheduledExaminations();
            this.Close();
            c.Show();
            c.doctorId.Text = doctorId.Text;
            for (int i = 0; i < examination.Count; i++)
            {
                if (examination[i].DoctorID.ToString() == doctorId.Text)
                {
                    c.lvUsers.Items.Add(new ExaminationDto() { Date = examination[i].Date });
                }
            }
        }

        private void Medicine_Click(object sender, RoutedEventArgs e)
        {
            Medicines m = new Medicines();
            this.Close();
            m.Show();
            m.doctorId.Text = doctorId.Text;
            List<MedicineDto> medicines = medicineController.GetAllValidateMedicines();
            List<MedicineDto> mediciness = medicineController.GetAllMedicines();
            string name1 = "";
            string quantity1 = "";
            string type1 = "";
            string medicine1 = "";
            for (int i = 0; i < medicines.Count; i++)
            {
                name1 = medicines[i].Name1;
                quantity1 = medicines[i].Quantity1.ToString();
                type1 = medicines[i].Type1;
                medicine1 = name1 + "," + quantity1 + "," + type1;
                m.medicinesValidateList.Items.Add(medicine1);
            }
            string name = "";
            string quantity = "";
            string type = "";
            string medicine = "";
            for (int i = 0; i < mediciness.Count; i++)
            {
                name = mediciness[i].Name1;
                quantity = mediciness[i].Quantity1.ToString();
                type = mediciness[i].Type1;
                medicine = name + "," + quantity + "," + type;
                m.ListOfAll.Items.Add(medicine);
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!isJmbgFieldEmpty() && is13Number())
            {
                string jmbg = patientController.ReviewPatientProfil(jmbgTextBox.Text);
                if (jmbg.Contains("Wrong")) { MessageBox.Show("Jmbg not found."); }
                else RedirectToPatientProfil(jmbg);
            }
        }

        private bool is13Number()
        {
            if (jmbgTextBox.Text.Length == 13) return true;
            else { MessageBox.Show("Jmbg must be 13 numbers."); return false; }
        }

        public bool isJmbgFieldEmpty()
        {
            if (jmbgTextBox.Text == "")
            {
                MessageBox.Show("Jmbg field can't be empty.");
                return true;
            }
            return false;
        }

        private void JmbgTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(jmbgTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("The field can't contain anything other than numbers.");
                jmbgTextBox.Text = jmbgTextBox.Text.Remove(jmbgTextBox.Text.Length - 1);
            }
            if (jmbgTextBox.Text.Length > 13)
            {
                MessageBox.Show("Jmbg must be 13 numbers.");
                jmbgTextBox.Text = jmbgTextBox.Text.Remove(jmbgTextBox.Text.Length - 1);
            }

        }

        private void RedirectToPatientProfil(string jmbg)
        {
            PatientProfil p = new PatientProfil();
            PatientDto patient = patientController.PatientInfo(jmbg);
            p.name.Content = patient.Name;
            p.surname.Content = patient.Surname;
            p.jmbg.Text = patient.Jmbg;
            p.doctorId.Text = doctorId.Text;
            p.doctorShift.Text = workersController.GetDoctorShift(doctorId.Text);
            string day = "";
            string mounth = "";
            string year = "";
            string yy = "";
            string dateOfBirth = "";
            for (int i = 0; i < 2; i++)
            {
                day += jmbg[i];
            }
            for (int j = 2; j < 4; j++)
            {
                mounth += jmbg[j];
            }
            for (int k = 4; k < 7; k++)
            {
                year += jmbg[k];
            }
            if (Int32.Parse(year) < 400)
            {
                yy = "2";
            }
            else yy = "1";

            dateOfBirth = day + "/" + mounth + "/" + yy + year;
            p.dateOfBirth.Content = dateOfBirth;
            this.Close();
            p.Show();
        }

        private void Show_Notifications_Click(object sender, RoutedEventArgs e)
        {
            lvUsers.Items.Clear();
            List<NotificationDto> n = notificationController.GetAllNotifications();
            string oldRoom = "";
            string oldDate = "";
            string newRoom = "";
            string newDate = "";
            string notifications = "";
            for (int i = 0; i < n.Count; i++)
            {
                if (n[i].OldExam.DoctorID.ToString() == doctorId.Text)
                {
                    oldRoom = n[i].OldExam.RoomID.ToString();
                    oldDate = n[i].OldExam.Date.ToString();

                    if (n[i].NewExam == null)
                    {
                        notifications = "[Old room:" + oldRoom + " Old date:" + oldDate + "]" + " - examination is cancelled";
                        lvUsers.Items.Add(notifications);
                    }
                    else
                    {
                        newRoom = n[i].NewExam.RoomID.ToString();
                        newDate = n[i].NewExam.Date.ToString();
                        notifications = "Old room:" + oldRoom + " Old date:" + oldDate + " New room:" + newRoom + " New date:" + newDate;
                        lvUsers.Items.Add(notifications);
                    }
                }
            }
        }
    }
}
