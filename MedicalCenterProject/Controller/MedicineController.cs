/***********************************************************************
 * Module:  MedicineController.cs
 * Purpose: Definition of the Class Controller.MedicineController
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class MedicineController
   {
        public MedicineController(MedicineService ms)
        {
            medicineService = ms;
        }

        public MedicineDto MedicineValidation(string medicine)
        {
            try
            {
                return medicineService.MedicineValidation(medicine);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Service.MedicineService medicineService;

        public List<MedicineDto> GetAllValidateMedicines()
        {
            return medicineService.GetAllValidateMedicines();
        }

        public List<MedicineDto> GetAllMedicines()
        {
            return medicineService.GetAllMedicines();
        }

        public MedicineDto DeleteMedicineFromValidationList(MedicineDto medicine)
        {
            return medicineService.DeleteMedicineFromValidationList(medicine);
        }

        public MedicineDto GetMedicine(string medicine)
        {
            return medicineService.GetMedicine(medicine);
        }
    }
}