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
    /// Interaction logic for ScheduleRecheck.xaml
    /// </summary>
    public partial class ScheduleRecheck : Window
    {

        private readonly ExaminationController examinationController;

        private int roomID;
        private DateTime date;

        public ScheduleRecheck()
        {
            InitializeComponent();
            var app = Application.Current as App;
            examinationController = app.ExaminationController;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            ExaminationDto examination = ProcessRequest();
            examinationController.ScheduleExamination(examination);
            MessageBox.Show("Examination scheduled on " + examination.Date.ToString("g") + " in room number " + examination.RoomID);
            this.Close();
        }

        private ExaminationDto ProcessRequest()
        {
            string selectedDate = AvailableAppointment.SelectedItem.ToString();
            date = DateTime.Parse(selectedDate);
            return new ExaminationDto(0, Int32.Parse(doctorId.Text), Int32.Parse(PatientId.Text), roomID, date);
        }

        private void CheckAvailableDate()
        {
            List<string> doctorFreeAppointments = examinationController.GetAllFreeAppointmentsByDoctorID(Int32.Parse(doctorId.Text), doctorShift.Text, InitializeDates());
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
                AvailableAppointment.Items.Clear();
                CheckAvailableDate();
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
    }
}
