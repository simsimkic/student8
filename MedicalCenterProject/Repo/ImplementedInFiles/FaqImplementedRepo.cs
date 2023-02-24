using MedicalCenterProject.Dtos;
using MedicalCenterProject.Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Repo.ImplementedInFiles
{
    class FaqImplementedRepo : ISaveInMemory<FaqDto>
    {

        private string filename;
        public FaqImplementedRepo(string filename)
        {
            this.filename = filename;
        }

        public FaqDto Create(FaqDto question)
        {
            File.AppendAllText(filename, question.Question + Environment.NewLine);
            return question;
        }

        public FaqDto Delete(FaqDto entity)
        {
            throw new NotImplementedException();
        }

        public List<FaqDto> GetAll()
        {
            List<FaqDto> unansweredQuestion = new List<FaqDto>();
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split('?');
                if (temp[1].Length != 0) continue;
                else unansweredQuestion.Add(ConvertStringToObject(temp));
            }
            return unansweredQuestion;
        }

        public string[] ReadFile(string _userFile)
        {
            string[] lines = File.ReadAllLines(_userFile).ToArray();
            if (lines.Length == 0) throw new NothingToReadFromFileException("File is empty.");
            else return lines;
        }

        private FaqDto ConvertStringToObject(string[] faqFromFile)
        {
            FaqDto faq = new FaqDto(faqFromFile[0], faqFromFile[1]);
            return faq;
        }

        public FaqDto GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public FaqDto GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public FaqDto Update(FaqDto entity, FaqDto none)
        {
            ConvertFileToString();
            foreach (var line in ReadFile(filename))
            {
                string[] temp = line.Split('?');
                if (temp[1].Length != 0) continue;
                else if (entity.Question == temp[0])
                {
                    return Replace(entity, ConvertStringToObject(temp));
                }
            }
            return null;
        }

        

        public FaqDto Replace(FaqDto entity, FaqDto faqfromFile)
        {
            string allTextFromFile = ConvertFileToString();
            allTextFromFile = allTextFromFile.Replace(faqfromFile.Question+"?", entity.Question+"?"+entity.Answer);
            File.WriteAllText(filename, allTextFromFile);
            return entity;
        }

        public string ConvertFileToString()
        {
            string allText = File.ReadAllText(filename);
            return allText;
        }

        public FaqDto GetByNameAndSurname()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            throw new NotImplementedException();
        }

        public FaqDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            throw new NotImplementedException();
        }

        public FaqDto GetByJMBG(string jmbg)
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
