using MaterialDesignThemes.Wpf.Transitions;
using MedicalCenterProject.Dtos;
using MedicalCenterProject.Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MedicalCenterProject.Repo.ImplementedInFiles
{
    class ExaminationImplementedRepo : ISaveInMemory<ExaminationDto>
    {
        private string examinationFile;
        private string separator;
        private string roomOccupationFile;
        private const int numberOfRooms = 9;
       

        public ExaminationImplementedRepo(string examinationFile, string separator, string roomOccupationFile)
        {
            this.examinationFile = examinationFile;
            this.separator = separator;
            this.roomOccupationFile = roomOccupationFile;
        }
        
        public ExaminationDto Create(ExaminationDto entity)
        {
            File.AppendAllText(examinationFile, ConvertObjectToString(entity, examinationFile) + Environment.NewLine);
            DateTime nextHour = entity.Date.AddHours(1);
            File.AppendAllText(roomOccupationFile, entity.RoomID + separator+ entity.Date.ToString("MM/dd/yyyy h:mm tt") + separator
                              +nextHour.ToString("MM/dd/yyyy h:mm tt") + Environment.NewLine);
            return entity;
        }

        public ExaminationDto Delete(ExaminationDto entity)
        {
            ExaminationDto oldExam =  GetExaminationByDoctorIDAndDate(entity.DoctorID, entity.Date);
            if (oldExam == null) throw new ExaminationDoesntExistException("That examination doesnt exist");

            List<string> allTextFromFile = ReadFile(examinationFile).ToList();
            int lineToBeDeleted = GetLineForExaminationCanceling(allTextFromFile, oldExam);
            allTextFromFile.RemoveAt(lineToBeDeleted-1);
            
            File.WriteAllText(examinationFile, FillNewFile(allTextFromFile));
            return entity;
        }

        private string FillNewFile(List<string> allTextFromFile)
        {
            string afterDelete = "";
            foreach (string line in allTextFromFile)
            {
                afterDelete += line + "\n";
            }
            return afterDelete;
        }

        private int GetLineForExaminationCanceling(List<string> allTextFromFile, ExaminationDto entity)
        {
            int lineCounter = 1;
            foreach (string line in allTextFromFile)
            {
                string[] temp = line.Split(',').ToArray();
                if (temp[0] == entity.ID.ToString()) return lineCounter;
                else lineCounter++;
            }

            return lineCounter;
        }

        public List<ExaminationDto> GetAll()
        {
            List<ExaminationDto> examinations = new List<ExaminationDto>();
            foreach (var line in ReadFile(examinationFile))
            {
                string[] temp = line.Split(',').ToArray();
                examinations.Add(ConvertStringToObject(temp));
            }
            return examinations;
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int roomID)
        {
            List<string> roomDates = new List<string>();
            foreach(var line in ReadFile(roomOccupationFile))
            {
                List<string> temp = line.Split(',').ToList();
                if (Int32.Parse(temp[0]) == roomID) roomDates.Add(temp[1]+","+temp[2]);
            }
            return roomDates;
        }

        public string GetFreeRoomForPotentialExamination(DateTime dateToCheck)
        {
            for (int i = 1; i <= numberOfRooms; i++)
            {
                List<string> takenDates = GetAllTakenAppointmentsByRoomID(i);
               
                if (takenDates.Count == 0) return i.ToString();

                if (CheckAvailableRoom(takenDates, dateToCheck, i) == null) continue;
                else return CheckAvailableRoom(takenDates, dateToCheck, i);
            }
            return null;
        }

        private string CheckAvailableRoom(List<string> takenDates, DateTime dateToCheck, int i)
        {
            for (int j = 0; j < takenDates.Count; j++)
            {
                List<string> datesSeparated = takenDates[j].Split(',').ToList();
                DateTime startDate = DateTime.Parse(datesSeparated[0]);
                DateTime endDate = DateTime.Parse(datesSeparated[1]);
                if (!(startDate <= dateToCheck && dateToCheck < endDate))
                {
                    if (takenDates.Count - 1 == j) return i.ToString();
                    else continue;
                }
                else break;
            }
            return null;
        }

        public string[] ReadFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename).ToArray();
            return lines;
        }

        private ExaminationDto ConvertStringToObject(string[] doctorFromFile)
        {
            if (doctorFromFile.Length != 0)
            {
                ExaminationDto doctorScheduledExamination = new ExaminationDto(Int32.Parse(doctorFromFile[0]), Int32.Parse(doctorFromFile[1])
                , Int32.Parse(doctorFromFile[2]), Int32.Parse(doctorFromFile[3]),
                DateTime.Parse(doctorFromFile[4]));
                return doctorScheduledExamination;
            }
            else return null;
        }

        private string ConvertObjectToString(ExaminationDto examination, string examinationFile)
        {
            int countLinesOfFile = File.ReadAllLines(examinationFile).Length;
            int examID = countLinesOfFile + 1;
            return examID.ToString() + separator + examination.DoctorID + separator
                                     + examination.PatientID + separator + examination.RoomID +separator+ 
                                       examination.Date.ToString("MM/dd/yyyy h:mm tt");
        }

        public ExaminationDto GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public ExaminationDto GetByNameAndSurname()
        {
            throw new NotImplementedException();
        }

        public ExaminationDto GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        private ExaminationDto GetExaminationByDoctorIDAndDate(int id, DateTime date)
        {
            string dateToCompare = date.ToString("MM/dd/yyyy h:mm tt");
          
            foreach (var line in ReadFile(examinationFile))
            {
                string[] temp = line.Split(',');
                
                if (temp[1] == id.ToString() && temp[4] == dateToCompare) { return ConvertStringToObject(temp); }
            }
            return null;
        }

        public ExaminationDto Update(ExaminationDto entity, ExaminationDto newEntity)
        {
            
            if (newEntity.Date >= DateTime.Now) return UpdateTime(entity, newEntity);
            else return UpdateRoom(entity, newEntity);
        }

        private ExaminationDto UpdateRoom(ExaminationDto entity, ExaminationDto newEntity)
        {
            foreach (var line in ReadFile(examinationFile))
            {
                string[] temp = line.Split(',');
                if (ConditionForUpdatingRoom(temp, entity)) return ReplaceRoom(entity, newEntity);
            }
            return null;
        }

        private bool ConditionForUpdatingRoom(string[] temp, ExaminationDto entity)
        {
            if (temp[1] == entity.DoctorID.ToString() && temp[3] == entity.RoomID.ToString()) return true;
            return false;
        }

        private ExaminationDto UpdateTime(ExaminationDto entity, ExaminationDto newEntity)
        {
            if (newEntity.Date == null) { }
            foreach (var line in ReadFile(examinationFile))
            {
                string[] temp = line.Split(',');
                if (ConditionForUpdatingTime(temp, entity)) return ReplaceTime(entity, newEntity);
            }
            return null;
        }

        private bool ConditionForUpdatingTime(string[] temp, ExaminationDto entity)
        {
            if (temp[1] == entity.DoctorID.ToString() && DateTime.Parse(temp[4]) == entity.Date) return true;
            return false;
        }

        private ExaminationDto ReplaceTime(ExaminationDto entity, ExaminationDto newEntity)
        {
            string allTextFromFile = ConvertFileToString();
            allTextFromFile = allTextFromFile.Replace(OldExamString(entity), NewTimeString(entity, newEntity));          
            File.WriteAllText(examinationFile, allTextFromFile);
            ReplaceTimeInRoomFile(entity, newEntity);
            return entity;
        }

        private ExaminationDto ReplaceRoom(ExaminationDto entity, ExaminationDto newEntity)
        {
            string allTextFromFile = ConvertFileToString();
            allTextFromFile = allTextFromFile.Replace(OldExamString(entity), NewRoomString(entity, newEntity));
            File.WriteAllText(examinationFile, allTextFromFile);
            ReplaceRoomInRoomFile(entity, newEntity);
            return entity;
        }

        private string ConvertRoomFileToString()
        {
            return File.ReadAllText(roomOccupationFile);
        }

        private void ReplaceRoomInRoomFile(ExaminationDto entity, ExaminationDto newEntity)
        {
            string allTextFromRoomFile = ConvertRoomFileToString();
            foreach(string line in ReadFile(roomOccupationFile))
            {
                string[] temp = line.Split(',').ToArray();
                
                if(temp[0] == entity.RoomID.ToString() && DateTime.Parse(temp[1]) == entity.Date)
                {
                    allTextFromRoomFile = allTextFromRoomFile.Replace(temp[0] + separator + temp[1] + separator + temp[2],
                                                                        newEntity.RoomID.ToString() + separator+ temp[1] + separator+ temp[2]);
                    break;
                }
            }
            File.WriteAllText(roomOccupationFile, allTextFromRoomFile);
        }

        private void ReplaceTimeInRoomFile(ExaminationDto entity, ExaminationDto newEntity)
        {
            string allTextFromRoomFile = ConvertRoomFileToString();
            foreach (string line in ReadFile(roomOccupationFile))
            {
                string[] temp = line.Split(',').ToArray();

                if (temp[0] == entity.RoomID.ToString() && DateTime.Parse(temp[1]) == entity.Date)
                {
                    allTextFromRoomFile = allTextFromRoomFile.Replace(temp[0] + separator + temp[1] + separator + temp[2],
                                                                        temp[0] + separator + newEntity.Date.ToString("g") + separator
                                                                        + newEntity.Date.AddHours(1).ToString("g"));
                    break;
                }
            }
            File.WriteAllText(roomOccupationFile, allTextFromRoomFile);
        }

        private string OldExamString(ExaminationDto entity)
        {
            return entity.ID.ToString() + separator + entity.DoctorID.ToString() +
                separator + entity.PatientID.ToString() + separator + entity.RoomID.ToString() + separator + entity.Date.ToString("MM/dd/yyyy h:mm tt");
        }

        private string NewRoomString(ExaminationDto entity, ExaminationDto newEntity)
        {
            return entity.ID.ToString() + separator + entity.DoctorID.ToString() + separator + entity.PatientID.ToString() +
                separator + newEntity.RoomID.ToString() + separator + entity.Date.ToString("MM/dd/yyyy h:mm tt");
        }

        private string NewTimeString(ExaminationDto entity, ExaminationDto newEntity)
        {
            return entity.ID.ToString() + separator + entity.DoctorID.ToString() + separator + entity.PatientID.ToString() +
                separator + entity.RoomID.ToString() + separator + newEntity.Date.ToString("MM/dd/yyyy h:mm tt");
        }

        public string ConvertFileToString()
        {
            string allText = File.ReadAllText(examinationFile);
            return allText;
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            return FilterDates(getScheduleAppointmentsByDoctorID(id), shift, dates);
        }

        public List<string> FilterDates(List<ExaminationDto> takenDates, string shift, List<DateTime> dates)
        {
            List<string> freeDates = new List<string>();
            if (Int32.Parse(shift) == 1) freeDates = FilteringForFirstShift(takenDates, dates);
            else freeDates = FilteringForSecondShift(takenDates, dates);
            //if there is more than one date in freedates, we must cut off extended date, else leave only extended
            if (freeDates.Count > 1) freeDates.RemoveAt(freeDates.Count - 1);
            return freeDates;
        }

        public List<string> FilteringForSecondShift(List<ExaminationDto> takenDates, List<DateTime> dates)
        {
            List<string> freeDates = InitializeValuesForSecondShift(dates);
            while (dates[0] <= dates[1]) ProcessFilteringSecondShift(takenDates, dates, freeDates);
            return freeDates;
        }

        public List<string> FilteringForFirstShift(List<ExaminationDto> takenDates, List<DateTime> dates)
        {
            List<string> freeDates = InitializeValuesForFirstShift(dates);
            while (dates[0] <= dates[1])  ProcessFilteringFirstShift(takenDates, dates, freeDates); 
            return freeDates;
        }

        public List<string> ProcessFilteringFirstShift(List<ExaminationDto> takenDates, List<DateTime> dates, List<string> freeDates)
        {
            for (int i = 0; i < takenDates.Count; i++)
            {
                if (dates[0].ToString("h:mm tt") == "2:00 PM") { dates[0] = dates[0].AddDays(1); dates[0] = dates[0].AddHours(-8); }
                else if (dates[0] != takenDates[i].Date)
                {
                    if (i == takenDates.Count - 1) ProcessLastDateCheckFirstShift(takenDates, dates, freeDates);
                    else continue;
                }
                else { AppointmentAlreadyExistFirstShift(dates); i = 0; }
            }
            return freeDates;
        }

        public List<string> ProcessFilteringSecondShift(List<ExaminationDto> takenDates, List<DateTime> dates, List<string> freeDates)
        {
            for (int i = 0; i < takenDates.Count; i++)
            {
                if (dates[0].ToString("h:mm tt") == "10:00 PM") { dates[0] = dates[0].AddDays(1); dates[0] = dates[0].AddHours(-8); } 
                if (dates[0] != takenDates[i].Date)
                {
                    if (i == takenDates.Count - 1) ProcessLastDateCheckSecondShift(takenDates, dates, freeDates); 
                    else continue;
                }
                else if (dates[0] == takenDates[i].Date) { AppointmentAlreadyExistSecondShift(dates); i = 0; }
            }
            return freeDates;
        }

        public void ProcessLastDateCheckFirstShift(List<ExaminationDto> takenDates, List<DateTime> dates, List<string> freeDates)
        {
            if (dates[0].ToString("h:mm tt") != "2:00 PM") ApproveExamination(dates, freeDates); 
            else
            {
                dates[0] = dates[0].AddDays(1);
                dates[0] = dates[0].AddHours(-8);
            }
        }

        public void ProcessLastDateCheckSecondShift(List<ExaminationDto> takenDates, List<DateTime> dates, List<string> freeDates)
        {
            if (dates[0].ToString("h:mm tt") != "10:00 PM") ApproveExamination(dates, freeDates);
            else
            {
                dates[0] = dates[0].AddDays(1);
                dates[0] = dates[0].AddHours(-8);
            }
        }

        public void ApproveExamination(List<DateTime> dates, List<string> freeDates)
        {
            string freeRoom = GetFreeRoomForPotentialExamination(dates[0]);
            if (freeRoom != null) freeDates.Add(dates[0].ToString("g") + "," + freeRoom);
            dates[0] = dates[0].AddHours(1);
        }

        public void AppointmentAlreadyExistFirstShift(List<DateTime> dates)
        {
            if (dates[0].ToString("h:mm tt") != "2:00 PM") dates[0] = dates[0].AddHours(1);
            else
            {
                dates[0] = dates[0].AddDays(1); 
                dates[0] = dates[0].AddHours(-8);
            }
        }

        public void AppointmentAlreadyExistSecondShift(List<DateTime> dates)
        {
            if (dates[0].ToString("h:mm tt") != "10:00 PM") dates[0] = dates[0].AddHours(1);
            else
            {
                dates[0] = dates[0].AddDays(1);
                dates[0] = dates[0].AddHours(-8);
            }
        }

        public List<string> InitializeValuesForFirstShift(List<DateTime> dates)
        {
            dates[0] = dates[0].AddHours(6);
            dates[1] = dates[1].AddHours(14);
            List<string> freeDates = new List<string>();
            return freeDates;
        }

        public List<string> InitializeValuesForSecondShift(List<DateTime> dates)
        {
            dates[0] = dates[0].AddHours(14);
            dates[1] = dates[1].AddHours(22);
            List<string> freeDates = new List<string>();
            return freeDates;
        }

        public List<ExaminationDto> getScheduleAppointmentsByDoctorID(int id)
        {
            List<ExaminationDto> scheduledAppointments = new List<ExaminationDto>();
            foreach(var line in ReadFile(examinationFile))
            {
                string[] temp = line.Split(',');
                if (Int32.Parse(temp[1]) == id) scheduledAppointments.Add(ConvertStringToObject(temp));
            }
            return scheduledAppointments;
        }

        public ExaminationDto GetByIDAndDate(int id, DateTime date)
        {
            return GetExaminationByDoctorIDAndDate(id, date);
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            List<string> allTakenDates = new List<string>();

            foreach(string line in ReadFile(examinationFile))
            {
                string[] temp = line.Split(',').ToArray();
                if (DateTime.Parse(temp[4]) == dateToCheck) allTakenDates.Add(ConvertOneExamLineToString(temp));
            }
            return allTakenDates;
        }

        public ExaminationDto GetByJMBG(string jmbg)
        {
            throw new NotImplementedException();
        }

        public MedicineDto ValidateMedicine(string medicine)
        {
            throw new NotImplementedException();
        }

        public List<MedicineDto> GetAllMedicine()
        {
            throw new NotImplementedException();
        }

        public MedicineDto GetMedicineByName(string medicine)
        {
            throw new NotImplementedException();
        }

        private string ConvertOneExamLineToString(string[] temp)
        {
            return temp[0] + separator + temp[1] + separator + temp[2] + separator + temp[3] + separator + temp[4];
        }

    }
}
