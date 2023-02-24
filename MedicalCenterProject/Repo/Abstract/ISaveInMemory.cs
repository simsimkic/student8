/***********************************************************************
 * Module:  ISaveInMemory.cs
 * Purpose: Definition of the Interface Model.ISaveInMemory
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
   public interface ISaveInMemory<T> 
   {
        T Create(T entity);
        T Update(T entity, T arg);
        T Delete(T entity);
        T GetByUsername(string username);
        T GetByID(int ID);
        T GetByJMBG(string jmbg);
        List<T> GetAll();
        List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates);
        List<string> GetAllTakenAppointmentsByRoomID(int id);
        T GetByIDAndDate(int id, DateTime date);
        List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck);
        MedicineDto ValidateMedicine(string medicine);
        List<MedicineDto> GetAllMedicine();
        MedicineDto GetMedicineByName(string medicine);
    }
}