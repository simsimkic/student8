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
    /// Interaction logic for CancelExamination.xaml
    /// </summary>
    public partial class CancelExamination : Window
    {
        private WorkersController workersController;
        private ExaminationController examinationController;
        private NotificationController notificationController;
        private int doctorID;

        public CancelExamination()
        {
            InitializeComponent();
            var app = Application.Current as App;
            workersController = app.WorkersController;
            examinationController = app.ExaminationController;
            notificationController = app.NotificationController;
            DoctorsList();
            DoctorList.Focus();
            DoctorList.IsDropDownOpen = true;
        }


        private void DoctorsList()
        {
            List<WorkersDto> workers = getAllDoctors();
            foreach (WorkersDto worker in workers)
            {
                DoctorList.Items.Add(worker.Name + ' ' + worker.Surname);
            }
        }

        public bool Validate()
        {
            if (date.Text == "" || DoctorList.SelectedIndex == -1)
            {
                MessageBox.Show("You must enter date and choose doctor");
                return false;
            }
            else if (ValidateDates(date.Text)) return true;
            MessageBox.Show("Format of date not valid, check date again.");
            return false;
        }

        public bool ValidateDates(string input)
        {
            DateTime now = DateTime.Now;
            DateTime date;
            if (DateTime.TryParseExact(input, "MM/dd/yyyy h:mm tt", null, System.Globalization.DateTimeStyles.None, out date))
            {
                if (date >= now) return true;
                else return false;
            }
            else return false;
        }

        private List<WorkersDto> getAllDoctors()
        {
            List<WorkersDto> doctors = workersController.GetWorkers();
            return doctors;
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

        private string[] DoctorNameAndSurname()
        {
            string[] doctorNameAndSurname = DoctorList.SelectedItem.ToString().Split(' ');
            return doctorNameAndSurname;
        }

        private void getDoctorID()
        {
            List<WorkersDto> doctors = getAllDoctors();
            foreach (WorkersDto doctor in doctors)
            {
                if (doctor.Name == DoctorNameAndSurname()[0] & doctor.Surname == DoctorNameAndSurname()[1])
                {
                    doctorID = doctor.ID;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                getDoctorID();
                DateTime dateTocancel = DateTime.Parse(date.Text); 
                ExaminationDto exam = new ExaminationDto(0, doctorID, 0, 0, dateTocancel);
                ExaminationDto canceledExam = examinationController.CancelExamination(exam);
                if (canceledExam == null) MessageBox.Show("That examination doesnt exist.");
                else {
                    NotificationDto cancelNotification = new NotificationDto(canceledExam, null);
                    notificationController.SendNotification(cancelNotification);
                }
            }
        }
    }
}
