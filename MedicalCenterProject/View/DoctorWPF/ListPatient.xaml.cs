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
    /// Interaction logic for ListPatient.xaml
    /// </summary>
    public partial class ListPatient : Window
    {

        private readonly PatientController patientController;
        private readonly WorkersController workersController;
        private readonly ExaminationController examinationController;
        private readonly NotificationController notificationController;
        private readonly MedicineController medicineController;

        public ListPatient()
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
            this.Close();
            d.Show();
            d.doctorId.Text = doctorId.Text;
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PatientProfil patient = new PatientProfil();
            List<PatientDto> p = patientController.GetAllPatients();
            PatientDto pdt = lvUsers.SelectedItem as PatientDto;
            string jmbg = pdt.Jmbg;
            for(int i = 0; i < p.Count; i++)
            {
                if(p[i].Jmbg == jmbg)
                {
                    patient.name.Content = p[i].Name;
                    patient.surname.Content = p[i].Surname;
                    patient.jmbg.Text = p[i].Jmbg;

                    string day = "";
                    string mounth = "";
                    string year = "";
                    string yy = "";
                    string dateOfBirth = "";
                    for (int j = 0; j < 2; j++)
                    {
                        day += jmbg[j];
                    }
                    for (int k = 2; k < 4; k++)
                    {
                        mounth += jmbg[k];
                    }
                    for (int l = 4; l < 7; l++)
                    {
                        year += jmbg[l];
                    }
                    if (Int32.Parse(year) < 400)
                    {
                        yy = "2";
                    }
                    else yy = "1";

                    dateOfBirth = day + "/" + mounth + "/" + yy + year;
                    patient.dateOfBirth.Content = dateOfBirth;

                    this.Close();
                    patient.Show();
                    patient.doctorId.Text = doctorId.Text;
                    patient.doctorShift.Text = workersController.GetDoctorShift(doctorId.Text);
                }
            }
            
            
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
