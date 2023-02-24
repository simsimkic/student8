/***********************************************************************
 * Module:  MedicineService.cs
 * Purpose: Definition of the Class Service.MedicineService
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Repo;
using System;
using System.Collections.Generic;

namespace Service
{
   public class MedicineService
   {
        public MedicineService(MedicineRepository mr)
        {
            medicineRepository = mr;
        }

        public MedicineDto MedicineValidation(string medicine)
        {
            return medicineRepository.ValidateMedicine(medicine);
        }

        public Repo.MedicineRepository medicineRepository;

        public List<MedicineDto> GetAllValidateMedicines()
        {
            return medicineRepository.GetAllValidateMedicines();
        }

        public List<MedicineDto> GetAllMedicines()
        {
            return medicineRepository.GetMedicinelList();
        }

        public MedicineDto DeleteMedicineFromValidationList(MedicineDto medicine)
        {
            return medicineRepository.DeleteMedicineFromValidationList(medicine);
        }

        public MedicineDto GetMedicine(string medicine)
        {
            return medicineRepository.GetMedicine(medicine);
        }
    }
}