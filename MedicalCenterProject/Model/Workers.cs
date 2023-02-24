/***********************************************************************
 * Module:  Workers.cs
 * Purpose: Definition of the Class Workers
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Workers : User
   {
      public List<Workers>[] WorkerList()
      {
         // TODO: implement
         return null;
      }
      
      public List<Workers>[] DoctorsOverview()
      {
         // TODO: implement
         return null;
      }
      
      public List<Secretary>[] SecretarysOverview()
      {
         // TODO: implement
         return null;
      }
   
      public Manager[] manager;
   
      private WorkPlace Workplace;
   
   }
}