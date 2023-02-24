/***********************************************************************
 * Module:  PatientController.cs
 * Purpose: Definition of the Class Controller.PatientController
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class PatientController
   {
      public PatientController(PatientService ps)
        {
            patientService = ps;
        }
      public List<PatientDto> GetAllPatients()
      {
            return patientService.GetAllPatients();
      }
      
      public Patient ChangeProfileData(Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Patient ProfileOverview(int patientId)
      {
         // TODO: implement
         return null;
      }

        public string ReviewPatientProfil(string jmbg)
        {
            try
            {
                return patientService.GoToPatientProfil(jmbg);
            }
            catch (Exception e)
            {
                return "Wrong jmbg";
            }
        }

        public PatientDto PatientInfo(string jmbg)
        {
            return patientService.GetPatientInfo(jmbg);
        }

        public string GetPatient(int patientId)
        {
            return patientService.GetPatient(patientId);
        }

        public string GetPatientId(string jmbg)
        {
            return patientService.GetPatientId(jmbg);
        }

        public Service.PatientService patientService;

        public int getPatientID(string username, string password)
        {
            return patientService.getPatientID(username, password);
        }

        public PatientDto PatientInfo1(string id1)
        {
            return patientService.GetPatientInfo1(id1);
        }
    }
}