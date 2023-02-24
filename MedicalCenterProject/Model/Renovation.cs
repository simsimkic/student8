/***********************************************************************
 * Module:  Renoviranje.cs
 * Purpose: Definition of the Class Renoviranje
 ***********************************************************************/

using System;

namespace Model
{
   public class Renovation
   {
      public Renovation ScheduleRenovation(int roomId)
      {
         // TODO: implement
         return null;
      }
   
      public MedicalCenter medicalCenter;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public MedicalCenter GetMedicalCenter()
      {
         return medicalCenter;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newMedicalCenter</param>
      public void SetMedicalCenter(MedicalCenter newMedicalCenter)
      {
         if (this.medicalCenter != newMedicalCenter)
         {
            if (this.medicalCenter != null)
            {
               MedicalCenter oldMedicalCenter = this.medicalCenter;
               this.medicalCenter = null;
               oldMedicalCenter.RemoveRenovation(this);
            }
            if (newMedicalCenter != null)
            {
               this.medicalCenter = newMedicalCenter;
               this.medicalCenter.AddRenovation(this);
            }
         }
      }
      public Rooms rooms;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Rooms GetRooms()
      {
         return rooms;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newRooms</param>
      public void SetRooms(Rooms newRooms)
      {
         if (this.rooms != newRooms)
         {
            if (this.rooms != null)
            {
               Rooms oldRooms = this.rooms;
               this.rooms = null;
               oldRooms.RemoveRenovation(this);
            }
            if (newRooms != null)
            {
               this.rooms = newRooms;
               this.rooms.AddRenovation(this);
            }
         }
      }
   
      private int Id;
      private DateTime Date;
   
   }
}