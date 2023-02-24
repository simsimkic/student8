/***********************************************************************
 * Module:  Lekar.cs
 * Purpose: Definition of the Class Lekar
 ***********************************************************************/

using System;

namespace Model
{
   public class Doctor : User
   {
      public Reports[] reports;
      public Examination examination;
      public Operation[] operation;
      public MedicalCenter medicalCenter;
   
      private int Id;
      private DoctorType Type;
   
   }
}