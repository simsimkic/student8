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
    /// Interaction logic for ChangeRoom.xaml
    /// </summary>
    public partial class ChangeRoom : Window
    {

        ExaminationController examinationController;
        WorkersController workersController;
        NotificationController notificationController;

        //parameteres for updating room of examination
        private int doctorID;
        public ChangeRoom()
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

        private void DoctorsList()
        {
            List<WorkersDto> workers = getAllDoctors();
            foreach (WorkersDto worker in workers)
            {
                DoctorList.Items.Add(worker.Name + ' ' + worker.Surname);
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
                int newRoom = Int32.Parse(NewRoom.Text);
                DateTime oldDate = DateTime.Parse(DateTextbox.Text);
               
                ExaminationDto partOldExamination = new ExaminationDto(0, doctorID, 0, 0, oldDate);
                ExaminationDto newExamination = examinationController.ChangeRoomOfExamination(partOldExamination, newRoom);
                if (newExamination == null) MessageBox.Show("That examination doesnt exist.");
            }
        }

        public bool Validate()
        {
            if (DateTextbox.Text == "" | NewRoom.Text == "")
            {
                MessageBox.Show("You must enter date and new room for updating");
                return false;
            }
            else if (ValidateDates(DateTextbox.Text)) return true;
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
