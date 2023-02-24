using Controller;
using MedicalCenterProject.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalCenterProject.View.SecretaryWPF
{
    /// <summary>
    /// Interaction logic for Examination.xaml
    /// </summary>
    public partial class Examination : Window
    {
        private WorkersController workersController;
        private ExaminationController examinationController;
        private PatientController patientController;

        //parameters for scheduling examination
        private int doctorID;
        private string doctorShift;
        private int roomID;
        private int patientID;
        private DateTime date;

        public Examination()
        {
            InitializeComponent();
            var app = Application.Current as App;
            workersController = app.WorkersController;
            examinationController = app.ExaminationController;
            patientController = app.PatientController;
            fromDate.Focus();
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

        private List<PatientDto> getAllPatients()
        {
            List<PatientDto> patients = patientController.GetAllPatients();
            
            return patients;
        }
        
        private string[] DoctorNameAndSurname()
        {
            string[] doctorNameAndSurname = DoctorsListBox.SelectedItem.ToString().Split(' ');
            return doctorNameAndSurname;
        }

        private void getDoctorID()
        {
            List<WorkersDto> doctors = getAllDoctors();
            foreach(WorkersDto doctor in doctors)
            {
                if(doctor.Name == DoctorNameAndSurname()[0] & doctor.Surname == DoctorNameAndSurname()[1]) { 
                    doctorID =  doctor.ID;
                    doctorShift = doctor.Shift;
                }
            }
        }

        private void DoctorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getDoctorID();
            AvailableAppointment.Items.Clear();
            CheckAvailableDate();
            ScheduleExaminationButton.IsEnabled = true;
            if (DoctorsListBox.SelectedIndex != -1) { Keyboard.Focus(AvailableAppointment); AvailableAppointment.IsDropDownOpen = true; }
        }

        private void CheckAvailableDate()
        {
            List<string> doctorFreeAppointments = examinationController.GetAllFreeAppointmentsByDoctorID(doctorID,doctorShift, InitializeDates());
            for(int i = 0; i < doctorFreeAppointments.Count; i++)
            {
                List<string> freeDates = doctorFreeAppointments[i].Split(',').ToList();
                AvailableAppointment.Items.Add(freeDates[0]);
            }
            roomID = FindRoomIdBasedOnWpfSelection(AvailableAppointment.Text, doctorFreeAppointments);
            date = FindDateBasedOnWpfSelection(AvailableAppointment.Text, doctorFreeAppointments);
        }

        private List<DateTime> InitializeDates()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Parse(fromDate.Text));
            dates.Add(DateTime.Parse(toDate.Text));
            return dates;
        }
        private int FindRoomIdBasedOnWpfSelection(string date, List<string> freeDates)
        {
            for(int i = 0; i < freeDates.Count; i++)
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

        private void FindAvailableAppointments_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                ConfigureWpf();
                List<WorkersDto> workers = getAllDoctors();
                foreach (WorkersDto worker in workers)
                {
                    DoctorsListBox.Items.Add(worker.Name + ' ' + worker.Surname);
                }
                Keyboard.ClearFocus();
                Keyboard.Focus(PatientJmbgTextbox);
            }
        }

        private void ConfigureWpf()
        {
            PatientJmbgLabel.Visibility = Visibility.Visible;
            PatientJmbgTextbox.Visibility = Visibility.Visible;
            AppointmentsLabel.Visibility = Visibility.Visible;
            SelectDoctorLabel.Visibility = Visibility.Visible;
            AvailableAppointment.Visibility = Visibility.Visible;
            DoctorsListBox.Visibility = Visibility.Visible;
        }

        private bool ValidatePatientData()
        {
            if (PatientJmbgTextbox.Text == "") { MessageBox.Show("Patient jmbg cant be empty."); return false; }
            
            else return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePatientData())
            {
                patientID = GetPatientID();
                ExaminationDto examination = ProcessRequest();
                examinationController.ScheduleExamination(examination);
                MessageBox.Show("Examination scheduled on " + examination.Date.ToString("g") + " in room number " +examination.RoomID);
                ConfigureWpfAfterSubmiting();
                fromDate.Focus();
            }
        }
        private ExaminationDto ProcessRequest()
        {
            return new ExaminationDto(0, doctorID , patientID, roomID, date);
        }

        private int GetPatientID()
        {
            List<PatientDto> patients = getAllPatients();
            foreach(PatientDto patient in patients)
            {
                
                if(patient.Jmbg == PatientJmbgTextbox.Text)
                {
                    return patient.ID;
                }
            }
            
            return 0;
        }
        private void ConfigureWpfAfterSubmiting()
        {
            PatientJmbgLabel.Visibility = Visibility.Collapsed;
            PatientJmbgTextbox.Visibility = Visibility.Collapsed;
            AppointmentsLabel.Visibility = Visibility.Collapsed;
            SelectDoctorLabel.Visibility = Visibility.Collapsed;
            AvailableAppointment.Visibility = Visibility.Collapsed;
            DoctorsListBox.Visibility = Visibility.Collapsed;
            fromDate.Text = "";
            toDate.Text = "";
            ScheduleExaminationButton.IsEnabled = false;
        }


        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) { 
                Keyboard.ClearFocus();
                this.Close();
                Secretary s = new Secretary();
                s.Show();
                s.examination.Focus();
            }
        }

      

        private void PatientJmbgTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab) DoctorsListBox.IsDropDownOpen = true; 
        }
    }
}
