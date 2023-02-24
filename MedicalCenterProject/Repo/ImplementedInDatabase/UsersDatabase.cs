/***********************************************************************
 * Module:  Database.cs
 * Purpose: Definition of the Class Model.Database
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Model
{
    public class UsersDatabase : ISaveInMemory<UserDto>
    {
        public UserDto Create(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public UserDto Delete(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public UserDto GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public UserDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public UserDto GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto Update(UserDto entity, UserDto none)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            throw new NotImplementedException();
        }

        public UserDto GetByJMBG(string jmbg)
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