using MedicalCenterProject.Dtos;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Repo.ImplementedInFiles
{
    public class WorkersImplementedRepo : ISaveInMemory<WorkersDto>
    {
        private string userFilename;
        private string filename;
        private string separator;

        public WorkersImplementedRepo(string filename, string separator, string userFilename)
        {
            this.userFilename = userFilename;
            this.filename = filename;
            this.separator = separator;
        }

        public WorkersDto Create(WorkersDto entity)
        {
            File.AppendAllText(filename, ConvertOBjectToString(entity) + Environment.NewLine);
            File.AppendAllText(userFilename, ConvertObjectToUserString(entity) + Environment.NewLine);
            return entity;
        }

        private string ConvertObjectToUserString(WorkersDto entity)
        {
            return entity.Name + separator + entity.Surname +
                   separator + entity.Email + separator + entity.Username + separator +
                   entity.Password + separator + entity.Workplace;
        }

        private string ConvertOBjectToString(WorkersDto entity)
        {
            int countLinesOfFile = File.ReadAllLines(filename).Length;
            int workerID = countLinesOfFile + 1;
            return workerID.ToString() + separator + entity.Name + separator + entity.Surname +
                   separator + entity.Email + separator + entity.Username + separator +
                   entity.Password + separator + entity.Workplace + separator + entity.Shift;
        }

        public WorkersDto Delete(WorkersDto entity)
        {
            throw new NotImplementedException();
        }

        public List<WorkersDto> GetAll()
        {
            return GetAllDoctorsData(ReadFile(filename));
        }

        public WorkersDto GetByID(int ID)
        {
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split(',').ToArray();
                if (Int32.Parse(temp[0]) == ID)
                {
                    return ConvertStringToObject(temp);
                }
            }
            return null;
        }

        public WorkersDto GetByUsername(string username)
        {
            WorkersDto user = GetUserData(username);
            return user;
        }

        public WorkersDto GetUserData(string username)
        {
            return GetUserByUsername(username, ReadFile(filename));
        }

        public WorkersDto GetUserByUsername(string username, string[] lines)
        {
            if (lines.Length != 0)
            {
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    if (username == entries[4]) return ConvertStringToObject(entries);
                }
            }
            return null;
        }

        public WorkersDto Update(WorkersDto entity, WorkersDto none)
        {
            throw new NotImplementedException();
        }

        public List<WorkersDto> GetAllDoctorsData(string[] lines)
        {
                List<WorkersDto> allDoctors = new List<WorkersDto>();
                foreach (var line in ReadFile(filename))
                {
                    string[] temp = line.Split(',');
                    if (temp[6] == "Doctor") allDoctors.Add(ConvertStringToObject(temp));
                }
                return allDoctors;
            
        }

        public string[] ReadFile(string userFile)
        {
            string[] lines = File.ReadAllLines(userFile).ToArray();
            return lines;
        }

        private WorkersDto ConvertStringToObject(string[] workerFromFile)
        {
            WorkersDto worker = new WorkersDto(int.Parse(workerFromFile[0]), workerFromFile[1], workerFromFile[2], workerFromFile[3],
            workerFromFile[4], workerFromFile[5], workerFromFile[6], workerFromFile[7]);
            return worker;
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            throw new NotImplementedException();
        }

        public WorkersDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            throw new NotImplementedException();
        }

        public WorkersDto GetByJMBG(string jmbg)
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
