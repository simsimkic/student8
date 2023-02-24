/***********************************************************************
 * Module:  RegisterPatientService.cs
 * Purpose: Definition of the Class Service.RegisterPatientService
 ***********************************************************************/

using Model;
using System;

namespace Service
{
   public class RegisterPatientService
   {
      public Patient RegisterPatient(User patientData, Priority patientPriority)
      {
         // TODO: implement
         return null;
      }
      
      public bool IsUsernameValid(String username)
      {
         // TODO: implement
         return false;
      }
      
      public bool IsEmailValid(String email)
      {
         // TODO: implement
         return false;
      }
   
      public Repo.RegisterPatientRepository registerPatientRepository;
   
   }
}