/***********************************************************************
 * Module:  SickBenefit.cs
 * Purpose: Definition of the Class SickBenefit
 ***********************************************************************/

using System;

namespace Model
{
   public class SickBenefit
   {
      public SickBenefit OpenSickBenefit(Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public SickBenefit CloseSickBenefit(SickBenefit sickbenefit)
      {
         // TODO: implement
         return null;
      }
      
      public SickBenefit ExtendSickBenefit(SickBenefit sickBenefit)
      {
         // TODO: implement
         return null;
      }
   
      public Patient patient;
   
      private int Id;
      private DateTime From;
      private DateTime To;
      private bool Active;
   
   }
}