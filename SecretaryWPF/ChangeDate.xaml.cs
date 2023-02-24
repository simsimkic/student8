using Controller;
using MedicalCenterProject.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    /// Interaction logic for ChangeDate.xaml
    /// </summary>
    public partial class ChangeDate : Window
    {
        //parameter for sending notification
        ExaminationDto oldExamination;
        ExaminationDto newExamination;
        // ends here

        WorkersController workersController;
        ExaminationController examinationController;
        NotificationController notificationController;

        //parameters for updating examination
        private int doctorID;

        public ChangeDate()
        {
            InitializeComponent();
            DoctorList.Focus();
            var app = Application.Current as App;
            workersController = app.WorkersController;
            examinationController = app.ExaminationController;
            notificationController = app.NotificationController;
            DoctorsList();
            DoctorList.IsDropDownOpen = true;
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
        private List<WorkersDto> getAllDoctors()
        {
            List<WorkersDto> doctors = workersController.GetWorkers();
            return doctors;
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
            if (oldDateTextbox.Text == "" | newDateTextbox.Text == "")
            {
                MessageBox.Show("You must enter old date and new date for updating");
                return false;
            }
            else if (ValidateDates(oldDateTextbox.Text) && ValidateDates(newDateTextbox.Text)) return true;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate()) {
                getDoctorID();
                ExaminationDto updatedExamination = ProcessRequest();
                if (updatedExamination == null) MessageBox.Show("That examination doesnt exist.");
                NotificationDto notification = new NotificationDto(ConfigureOldExamination(updatedExamination), 
                                                                   ConfigureNewExamination(updatedExamination));
                notificationController.SendNotification(notification);
            }
        }

        private ExaminationDto ConfigureOldExamination(ExaminationDto updatedExamination)
        {
            return new ExaminationDto(updatedExamination.ID, updatedExamination.DoctorID, updatedExamination.PatientID,
                                                updatedExamination.RoomID, DateTime.Parse(oldDateTextbox.Text));
        }

        private ExaminationDto ConfigureNewExamination(ExaminationDto updatedExamination)
        {
            return new ExaminationDto(updatedExamination.ID, updatedExamination.DoctorID, updatedExamination.PatientID,
                                                updatedExamination.RoomID, DateTime.Parse(newDateTextbox.Text));
        }

        private ExaminationDto ProcessRequest()
        {
            DateTime oldDate = DateTime.Parse(oldDateTextbox.Text);
            DateTime newDate = DateTime.Parse(newDateTextbox.Text);
            ExaminationDto partOldExamination = new ExaminationDto(0, doctorID, 0, 0, oldDate);
            ExaminationDto UpdatedExamination = examinationController.ChangeTimeOfExamination(partOldExamination, newDate);
            return UpdatedExamination;
        }
    }
}
