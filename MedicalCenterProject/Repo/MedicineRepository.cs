/***********************************************************************
 * Module:  MedicineRepository.cs
 * Purpose: Definition of the Class Repository.MedicineRepository
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using MedicalCenterProject.Repo.ImplementedInFiles;
using Model;
using System;
using System.Collections.Generic;

namespace Repo
{
   public class MedicineRepository
   {
        private string filename;
        private string filenameMedicines;
        private string separator;
        private ISaveInMemory<MedicineDto> medicineMemory;

        public MedicineRepository(string filename, string filenameMedicines, string separator)
        {
            this.filename = filename;
            this.filenameMedicines = filenameMedicines;
            this.separator = separator;
            MakeInstance();
        }

        public void MakeInstance()
        {
            if (medicineMemory == null) medicineMemory = new MedicineImplementedRepo(filename, filenameMedicines, separator);
        }

        public List<MedicineDto> GetMedicinelList()
        {
            return medicineMemory.GetAllMedicine();
        }

        public MedicineDto ValidateMedicine(string medicine)
        {
            MedicineDto medicineApprove = medicineMemory.ValidateMedicine(medicine);
            medicineMemory.Create(medicineApprove);
            return medicineApprove;
        }

        public List<MedicineDto> GetAllValidateMedicines()
        {
            return medicineMemory.GetAll();
        }

        public MedicineDto DeleteMedicineFromValidationList(MedicineDto medicine)
        {
            return medicineMemory.Delete(medicine);
        }

        public MedicineDto GetMedicine(string medicine)
        {
            return medicineMemory.GetMedicineByName(medicine);
        }

    }
}