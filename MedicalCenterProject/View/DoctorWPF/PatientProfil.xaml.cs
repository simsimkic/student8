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
    /// Interaction logic for PatientProfil.xaml
    /// </summary>
    public partial class PatientProfil : Window
    {

        private readonly PatientController patientController;
        private readonly WorkersController workersController;
        private readonly ExaminationController examinationController;
        private readonly NotificationController notificationController;
        private readonly MedicineController medicineController;

        public PatientProfil()
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

        private void MedicalRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScheduleRecheck_Click(object sender, RoutedEventArgs e)
        {
            ScheduleRecheck s = new ScheduleRecheck();
            s.PatientId.Text = patientController.GetPatientId(jmbg.Text);
            s.doctorId.Text = doctorId.Text;
            s.doctorShift.Text = doctorShift.Text;
            s.Show();
        }

        private void NewExamination_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScheduleAnOperation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
