using MedicalCenterProject.Dtos;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCenterProject.Repo.ImplementedInFiles
{
    class MedicineImplementedRepo : ISaveInMemory<MedicineDto>
    {

        private string filename;
        private string filenameMedicines;
        private string separator;
        public MedicineImplementedRepo(string filename, string filenameMedicines, string separator)
        {
            this.filename = filename;
            this.filenameMedicines = filenameMedicines;
            this.separator = separator;
        }

        public string[] ReadFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename).ToArray();
            return lines;
        }

        public string[] ReadFile1(string filenameMedicines)
        {
            string[] lines = File.ReadAllLines(filenameMedicines).ToArray();
            return lines;
        }

        public MedicineDto Create(MedicineDto entity)
        {
            File.AppendAllText(filenameMedicines, ConvertObjectToString(entity));

            return entity;
        }

        private string ConvertObjectToString(MedicineDto medicine)
        {
            return medicine.Id1 + separator
                                     + medicine.Name1 + separator + medicine.Quantity1 + separator +
                                       medicine.Type1 + separator + medicine.Approved1 + Environment.NewLine;
        }

        public List<MedicineDto> GetAll()
        {
            List<MedicineDto> medicine = new List<MedicineDto>();
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split(',').ToArray();
                medicine.Add(ConvertStringToObject(temp));
            }
            return medicine;
        }

        private MedicineDto ConvertStringToObject(string[] medicineFromFile)
        {
            MedicineDto medicines = new MedicineDto(Int32.Parse(medicineFromFile[0]), medicineFromFile[1], Int32.Parse(medicineFromFile[2]), medicineFromFile[3]);

            return medicines;
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            throw new NotImplementedException();
        }

        public MedicineDto GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public MedicineDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public MedicineDto GetByJMBG(string jmbg)
        {
            throw new NotImplementedException();
        }

        public MedicineDto GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public MedicineDto Update(MedicineDto entity, MedicineDto arg)
        {
            throw new NotImplementedException();
        }

        public MedicineDto ValidateMedicine(string medicine)
        {
            MedicineDto medicineDto = new MedicineDto();
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split(',').ToArray();
                if(temp[1] == medicine)
                {
                    medicineDto = ConvertStringToObject(temp);
                    medicineDto.Approved1 = true;
                    return medicineDto;
                }
            }
            return null;
        }

        public List<MedicineDto> GetAllMedicine()
        {
            List<MedicineDto> medicine = new List<MedicineDto>();
            foreach (var line in ReadFile(filenameMedicines))
            {
                string[] temp = line.Split(',').ToArray();
                medicine.Add(ConvertStringToObject(temp));
            }
            return medicine;
        }

        public MedicineDto Delete(MedicineDto entity)
        {
            MedicineDto medicine = GetMedicineById(entity.Id1);
          
            List<string> allTextFromFile = ReadFile(filename).ToList();
            int lineToBeDeleted = GetLineForMedicineValidation(allTextFromFile, medicine);
            allTextFromFile.RemoveAt(lineToBeDeleted - 1);
            string afterDelete = "";
            foreach (string line in allTextFromFile)
            {
                afterDelete += line + "\n";
            }

            File.WriteAllText(filename, afterDelete);
            return entity;
        }

        private MedicineDto GetMedicineById(int id1)
        {
            MedicineDto medicine = new MedicineDto();
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split(',').ToArray();
                if(temp[0] == id1.ToString())
                {
                    medicine = ConvertStringToObject(temp);
                }
            }
            return medicine;
        }

        private int GetLineForMedicineValidation(List<string> allTextFromFile, MedicineDto entity)
        {
            int lineCounter = 1;
            foreach (string line in allTextFromFile)
            {
                string[] temp = line.Split(',').ToArray();
                if (temp[0] == entity.Id1.ToString()) return lineCounter;
                else lineCounter++;
            }

            return lineCounter;
        }

        public MedicineDto GetMedicineByName(string medicine)
        {
            MedicineDto medicine1 = new MedicineDto();
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split(',').ToArray();
                if (temp[1] == medicine)
                {
                    medicine1 = ConvertStringToObject(temp);
                }
            }
            return medicine1;
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            throw new NotImplementedException();
        }
    }
}
