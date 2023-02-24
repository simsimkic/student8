using MedicalCenterProject.Dtos;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MedicalCenterProject.Repo.ImplementedInFiles
{
    public class NotificationImplementedRepo : ISaveInMemory<NotificationDto>
    {
        private string filename;
        public NotificationImplementedRepo(string filename)
        {
            this.filename = filename;
        }

        public string[] ReadFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename).ToArray();
            return lines;
        }

        public NotificationDto Create(NotificationDto entity)
        {
            string oldExam = ConvertOldExamToString(entity);
            if (entity.NewExam == null) 
            { 
                File.AppendAllText(filename, oldExam + "-" + Environment.NewLine); return entity; 
            }
            else
            {
                string newExam = ConvertNewExamToString(entity);
                File.AppendAllText(filename, oldExam + "-" + newExam + Environment.NewLine);
                return entity;
            }
        }

        private string ConvertOldExamToString(NotificationDto notification)
        {
            ExaminationDto examination = notification.OldExam;
            return examination.DoctorID + "," +
                   examination.PatientID + "," + examination.RoomID + "," + examination.Date.ToString("MM/dd/yyyy h:mm tt");
        }

        private string ConvertNewExamToString(NotificationDto notification)
        {
            ExaminationDto examination = notification.NewExam;
            return examination.DoctorID + "," +
                   examination.PatientID + "," + examination.RoomID + "," + examination.Date.ToString("MM/dd/yyyy h:mm tt");
        }

        public NotificationDto Delete(NotificationDto entity)
        {
            throw new NotImplementedException();
        }

        public List<NotificationDto> GetAll()
        {
            List<NotificationDto> notificationDtos = new List<NotificationDto>();
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split('-').ToArray();
                string[] oldExem = temp[0].Split(',').ToArray();
                string[] newExem = temp[1].Split(',').ToArray();
                if (temp[1] == "")
                {
                    notificationDtos.Add(ConvertStringToObjectForCancelExam(oldExem));
                }
                else
                {
                    notificationDtos.Add(ConvertStringToObject(oldExem, newExem));
                }
            }
            return notificationDtos;
        }

        private NotificationDto ConvertStringToObject(string[] oldExam, string[] newExam)
        {
            ExaminationDto oldExam1 = new ExaminationDto(Int32.Parse(oldExam[0]), Int32.Parse(oldExam[1]), Int32.Parse(oldExam[2]), DateTime.Parse(oldExam[3]));
            ExaminationDto newExam1 = new ExaminationDto(Int32.Parse(newExam[0]), Int32.Parse(newExam[1]), Int32.Parse(newExam[2]), DateTime.Parse(newExam[3]));
            NotificationDto notification = new NotificationDto(oldExam1, newExam1);

            return notification;
        }

        private NotificationDto ConvertStringToObjectForCancelExam(string[] oldExam)
        {
            ExaminationDto oldExam1 = new ExaminationDto(Int32.Parse(oldExam[0]), Int32.Parse(oldExam[1]), Int32.Parse(oldExam[2]), DateTime.Parse(oldExam[3]));
            NotificationDto notification = new NotificationDto(oldExam1, null);

            return notification;
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            throw new NotImplementedException();
        }

        public NotificationDto GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public NotificationDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public NotificationDto GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public NotificationDto Update(NotificationDto entity, NotificationDto arg)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            throw new NotImplementedException();
        }

        public NotificationDto GetByJMBG(string jmbg)
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
    }
}
