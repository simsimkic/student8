/***********************************************************************
 * Module:  Sekretar.cs
 * Purpose: Definition of the Class Sekretar
 ***********************************************************************/

using System;

namespace Model
{
   public class Secretary : User
   {
      public Faq faq;
      public PatientRegistration registerPatient;
      public MedicalCenter medicalCenter;
   
      private int Id;
   
   }
}