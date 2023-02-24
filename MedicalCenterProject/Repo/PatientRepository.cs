/***********************************************************************
 * Module:  PatientRepository.cs
 * Purpose: Definition of the Class Repository.PatientRepository
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using MedicalCenterProject.Exceptions;
using MedicalCenterProject.Repo.ImplementedInFiles;
using Model;
using System;
using System.Collections.Generic;

namespace Repo
{
   public class PatientRepository
   {
        private string patientfile;
        private string separator;
        private ISaveInMemory<PatientDto> patients;
      public PatientRepository(string patientFile, string separator)
        {
            this.patientfile = patientFile;
            this.separator = separator;
            MakeInstance();
        }
      public List<PatientDto> GetAllPatients()
      {
            return patients.GetAll();
      }
     
      private void MakeInstance()
        {
            if (patients == null) patients = new PatientsImplementedRepo(patientfile, separator);
        }

        public PatientDto GetPatientInfo(string jmbg)
        {
            PatientDto p = patients.GetByJMBG(jmbg);
            if (p == null) { throw new InvalidJmbgException("Incorect jmbg"); }
            else return p;
        }

        public string GetPatientId(int patientId)
        {
            PatientDto p = patients.GetByID(patientId);
            if (p == null) { throw new InvalidIdException("Incorect patient ID"); }
            else return p.Name + p.Surname;
        }

        public string GetIdPatient(string jmbg)
        {
            PatientDto p = patients.GetByJMBG(jmbg);
            if (p == null) { throw new InvalidJmbgException("Incorect jmbg"); }
            else return p.ID.ToString();
        }

        public string GetPatient(string jmbg)
        {
            PatientDto p = patients.GetByJMBG(jmbg);
            if (p == null) { throw new InvalidJmbgException("Incorect jmbg"); }
            else return p.Jmbg;
        }

        public int getPatientID(string username, string password)
        {
            PatientDto user = patients.GetByUsername(username);
            if (user == null) { throw new InvalidUsernameException("Incorect username"); }
            else if (user.Password != password.GetHashCode().ToString()) throw new InvalidPasswordException("Incorect password");
            else return user.ID;
        }

        public PatientDto GetPatientInfo1(string id1)
        {

            if (patients.GetByID(Int32.Parse(id1)) == null) { throw new InvalidIdException("Incorect id"); }
            else return patients.GetByID(Int32.Parse(id1));
        }

    }
}