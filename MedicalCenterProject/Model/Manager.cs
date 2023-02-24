/***********************************************************************
 * Module:  Upravnik.cs
 * Purpose: Definition of the Class Upravnik
 ***********************************************************************/

using System;

namespace Model
{
   public class Manager : User
   {
      public Reports[] reports;
      public DoctorsShift doctorsShift;
      public Workers workers;
      public Equipment equipment;
      public WorkersRegistration registerWorkers;
      public MedicalCenter medicalCenter;
   
      private int Id;
   
   }
}