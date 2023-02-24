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
    class FeedbackImplementedRepo : ISaveInMemory<FeedbackDto>
    {
        private string filename;

        public FeedbackImplementedRepo(string filename)
        {
            this.filename = filename;
        }

        public FeedbackDto Create(FeedbackDto entity)
        {
            entity.ID = CountLines(filename) + 1;
            File.AppendAllText(filename, entity.ID + "." + entity.Content + Environment.NewLine);
            return entity;
        }

       
        public int CountLines(string filename)
            => File.ReadLines(filename).Count();
        

        public FeedbackDto Delete(FeedbackDto entity)
        {
            throw new NotImplementedException();
        }

        public FeedbackDto GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public FeedbackDto GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public FeedbackDto Update(FeedbackDto entity, FeedbackDto none)
        {
            throw new NotImplementedException();
        }

        public List<FeedbackDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public FeedbackDto GetByNameAndSurname()
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

        public FeedbackDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            throw new NotImplementedException();
        }

        public FeedbackDto GetByJMBG(string jmbg)
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
