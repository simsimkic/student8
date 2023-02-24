using MedicalCenterProject.Dtos;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Repo.ImplementedInFiles
{
    public class PatientsImplementedRepo : ISaveInMemory<PatientDto>
    {
        private string patientfile;
        private string separator;
        public PatientsImplementedRepo(string filename, string separator)
        {
            this.patientfile = filename;
            this.separator = separator;
        }
        public PatientDto Create(PatientDto entity)
        {
            throw new NotImplementedException();
        }

        public PatientDto Delete(PatientDto entity)
        {
            throw new NotImplementedException();
        }

        public string[] ReadFile(string patientfile)
        {
            string[] lines = File.ReadAllLines(patientfile).ToArray();
            return lines;
        }

        public List<PatientDto> GetAll()
        {
            List<PatientDto> patients = new List<PatientDto>();
            foreach(var line in ReadFile(patientfile))
            {
                string[] temp = line.Split(',').ToArray();
                patients.Add(ConvertStringToObject(temp));
            }
            return patients;
        }

        private PatientDto ConvertStringToObject(string[] patientFromFile)
        {
            PatientDto patient = new PatientDto(Int32.Parse(patientFromFile[0]), patientFromFile[1], patientFromFile[2],
                                               patientFromFile[3], patientFromFile[4], patientFromFile[5], patientFromFile[6]);
            
            return patient;
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public PatientDto GetByID(int ID)
        {
            foreach (var line in ReadFile(patientfile))
            {
                string[] temp = line.Split(',').ToArray();
                if (Int32.Parse(temp[0]) == ID)
                {
                    return ConvertStringToObject(temp);
                }
            }
            return null;
        }

        public PatientDto GetByJMBG(string jmbg)
        {
            foreach (var line in ReadFile(patientfile))
            {
                string[] temp = line.Split(',').ToArray();
                if (temp[6] == jmbg)
                {
                    return ConvertStringToObject(temp);
                }
            }
            return null;
        }

        public PatientDto GetByUsername(string username)
        {
            PatientDto patient = GetUserData(username);
            return patient;
        }

        public PatientDto GetUserData(string username)
        {
            return GetPatientByUsername(username, ReadFile(patientfile));
        }

        public PatientDto GetPatientByUsername(string username, string[] lines)
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

        public PatientDto Update(PatientDto entity, PatientDto none)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            throw new NotImplementedException();
        }

        public PatientDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
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
