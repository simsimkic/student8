using Controller;
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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        private ExaminationController examinationController;
        public Rooms()
        {
            var app = Application.Current as App;
            examinationController = app.ExaminationController;
            InitializeComponent();
            room1Button.Focus();
        }

 
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                Secretary s = new Secretary();
                s.Show();
                s.examination.Focus();
            }
        }

        private void room1Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(1);
            for(int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                if(CheckDate(separatedDates)) ro.OccupationTextbox.Text += separatedDates[0] + "," + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private bool CheckDate(List<string> separatedDates)
        {
            DateTime dateFrom = DateTime.Parse(separatedDates[0]);
            DateTime dateTo = DateTime.Parse(separatedDates[1]);
            DateTime today = DateTime.Now;
            if (dateFrom <= today && today <= dateTo) return true;
            else if (dateFrom >= today) return true;
            else return false;
        }

        private void room2Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(2);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private void room3Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(3);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private void room4Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(4);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private void room5Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(5);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private void room6Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(6);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private void room7Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(7);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private void room8Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(8);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }

        private void room9Button_Click(object sender, RoutedEventArgs e)
        {
            RoomOcupation ro = new RoomOcupation();
            List<string> takenDates = examinationController.GetAllTakenAppointmentsByRoomID(9);
            for (int i = 0; i < takenDates.Count; i++)
            {
                List<string> separatedDates = takenDates[i].Split(',').ToList();
                ro.OccupationTextbox.Text += separatedDates[0] + " , " + separatedDates[1] + "\r\n";
            }
            ro.Show();
            ro.OccupationTextbox.Focus();
        }
    }
}