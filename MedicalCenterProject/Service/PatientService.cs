/***********************************************************************
 * Module:  PatientService.cs
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Repo;
using System;
using System.Collections.Generic;

namespace Service
{
   public class PatientService
   {
      public PatientService(PatientRepository pr)
        {
            patientRepository = pr;
        }
      public List<PatientDto> GetAllPatients()
      {
            return patientRepository.GetAllPatients();
      }
      
      public Patient ChangeProfileData(Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Patient ProfileOverview(Model.Patient patient)
      {
         // TODO: implement
         return null;
      }

        public string GoToPatientProfil(string jmbg)
        {
            return patientRepository.GetPatient(jmbg);
        }

        public PatientDto GetPatientInfo(string jmbg)
        {
            return patientRepository.GetPatientInfo(jmbg);
        }

        public string GetPatient(int patientId)
        {
            return patientRepository.GetPatientId(patientId);
        }

        public string GetPatientId(string jmbg)
        {
            return patientRepository.GetIdPatient(jmbg);
        }

        public Repo.PatientRepository patientRepository;

        public int getPatientID(string username, string password)
        {
            return patientRepository.getPatientID(username, password);
        }

        public PatientDto GetPatientInfo1(string id1)
        {
            return patientRepository.GetPatientInfo1(id1);
        }
    }
}