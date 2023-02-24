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
    /// Interaction logic for RoomOcupation.xaml
    /// </summary>
    public partial class RoomOcupation : Window
    {
        
        public RoomOcupation()
        {
            InitializeComponent();
            OccupationTextbox.Focus();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
                Rooms r = new Rooms();
                r.Show();
                r.room1Button.Focus();
            }
        }

        private void OccupationTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
                Rooms r = new Rooms();
                r.Show();
                r.room1Button.Focus();
            }
        }

        public bool Validate()
        {
            if (DateTextbox.Text == "")
            {
                MessageBox.Show("You must enter date");
                Keyboard.Focus(DateTextbox);
                return false;
            }
            else if (ValidateDate()) return true;
            MessageBox.Show("Format of dates not valid, check dates again.");
            return false;
        }

        private bool ValidateDate()
        { 
                DateTime now = DateTime.Now;
                DateTime date;
                if (DateTime.TryParse(DateTextbox.Text, out date))
                {
                    if (date >= now) return true;
                    else return false;
                }
                else return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                List<string> allDates = GetAllDatesFromWpf();
                
                DateTime enteredDate = DateTime.Parse(DateTextbox.Text);
                OccupationTextbox.Clear();
                for (int i = 0; i < allDates.Count-1; i++)
                {
                    List<DateTime> datesFromOneLine = GetDatesFromOneLine(allDates[i]);
                    
                    if (datesFromOneLine[0].Date <= enteredDate.Date && enteredDate.Date < datesFromOneLine[1])
                    {
                        OccupationTextbox.Text += datesFromOneLine[0].ToString("g") + "," + datesFromOneLine[1].ToString("g") + "\r\n";
                    }
                }
            }
        }

    

        private List<DateTime> GetDatesFromOneLine(string allDates)
        {
            List<string> separatedDates = allDates.Split(',').ToList();
            DateTime firstDate = DateTime.Parse(separatedDates[0]);
            DateTime secondDate = DateTime.Parse(separatedDates[1]);
            List<DateTime> dates = new List<DateTime>();
            dates.Add(firstDate);
            dates.Add(secondDate);
            return dates;
        }

        private List<string> GetAllDatesFromWpf()
        {
            List<string> lines = new List<string>();
            int lineCount = OccupationTextbox.LineCount;
            
            for (int line = 0; line < lineCount; line++) lines.Add(OccupationTextbox.GetLineText(line));

            return lines;
        }
    }
}
