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

namespace MedicalCenterProject.View.PatientWPF
{
    /// <summary>
    /// Interaction logic for ScheduleExamination.xaml
    /// </summary>
    public partial class ScheduleExamination : Window
    {
        private readonly ExaminationController examinationController;
        private WorkersController workersController;


        private int roomID;
        private DateTime date;
        private int doctorID;
        private string doctorShift;
        public ScheduleExamination()
        {
            InitializeComponent();
            var app = Application.Current as App;
            examinationController = app.ExaminationController;
            workersController = app.WorkersController;
        }

     

        private ExaminationDto ProcessRequest()
        {
            string selectedDate = AvailableAppointment.SelectedItem.ToString();
            date = DateTime.Parse(selectedDate);
            return new ExaminationDto(0, doctorID, Int32.Parse(patientIdTextBox.Text), roomID, date);
        }

        private void CheckAvailableDate()
        {
            
            List<string> doctorFreeAppointments = examinationController.GetAllFreeAppointmentsByDoctorID(doctorID, doctorShift, InitializeDates());
            for (int i = 0; i < doctorFreeAppointments.Count; i++)
            {
                List<string> freeDates = doctorFreeAppointments[i].Split(',').ToList();
                AvailableAppointment.Items.Add(freeDates[0]);
            }
            roomID = FindRoomIdBasedOnWpfSelection(AvailableAppointment.Text, doctorFreeAppointments);
        }

        private int FindRoomIdBasedOnWpfSelection(string date, List<string> freeDates)
        {
            for (int i = 0; i < freeDates.Count; i++)
            {
                if (freeDates[i].Contains(date))
                {
                    List<string> separate = freeDates[i].Split(',').ToList();
                    return Int32.Parse(separate[1]);
                }
            }
            return 0;
        }

        private DateTime FindDateBasedOnWpfSelection(string date, List<string> freeDates)
        {
            for (int i = 0; i < freeDates.Count; i++)
            {
                if (freeDates[i].Contains(date))
                {
                    List<string> separate = freeDates[i].Split(',').ToList();
                    return DateTime.Parse(separate[0]);
                }
            }
            return DateTime.Now;
        }

        private List<DateTime> InitializeDates()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Parse(fromDate.Text));
            dates.Add(DateTime.Parse(toDate.Text));
            return dates;
        }

        private void FindAvailableAppointments_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                List<WorkersDto> workers = getAllDoctors();
                foreach (WorkersDto worker in workers)
                {
                    DoctorListBox.Items.Add(worker.Name + ' ' + worker.Surname);
                }
            }
        }

        public bool Validate()
        {
            if (toDate.Text == "" | fromDate.Text == "")
            {
                MessageBox.Show("You must enter starting date and ending date for range");
                Keyboard.Focus(fromDate);
                return false;
            }
            else if (ValidateDates(toDate.Text) && ValidateDates(fromDate.Text)) return true;
            MessageBox.Show("Format of dates not valid, check dates again.");
            return false;
        }

        public bool ValidateDates(string input)
        {
            DateTime now = DateTime.Now;
            DateTime date;
            if (DateTime.TryParse(input, out date))
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

        private string[] DoctorNameAndSurname()
        {
            string[] doctorNameAndSurname = DoctorListBox.SelectedItem.ToString().Split(' ');
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
                    doctorShift = doctor.Shift;
                }
            }
        }

       

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Patient pt = new Patient();
            pt.Show();
            pt.patientIdTextBox.Text = this.patientIdTextBox.Text;
            this.Close();
                ExaminationDto examination = ProcessRequest();
                examinationController.ScheduleExamination(examination);
                MessageBox.Show("Examination scheduled on " + examination.Date.ToString("g") + " in room number " + examination.RoomID);

        }

        private void DoctorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getDoctorID();
            AvailableAppointment.Items.Clear();
            CheckAvailableDate();
            ScheduleExaminationButton.IsEnabled = true;
            if (DoctorListBox.SelectedIndex != -1) { Keyboard.Focus(AvailableAppointment); AvailableAppointment.IsDropDownOpen = true; }
        }
    }
}
