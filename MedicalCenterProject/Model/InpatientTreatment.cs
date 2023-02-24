/***********************************************************************
 * Module:  InpatientTreatment.cs
 * Purpose: Definition of the Class InpatientTreatment
 ***********************************************************************/

using System;

namespace Model
{
   public class InpatientTreatment
   {
      public InpatientTreatment inpatientTreatment(Rooms room, Patient patient)
      {
         // TODO: implement
         return null;
      }
   
      public Patient patient;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Patient GetPatient()
      {
         return patient;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newPatient</param>
      public void SetPatient(Patient newPatient)
      {
         if (this.patient != newPatient)
         {
            if (this.patient != null)
            {
               Patient oldPatient = this.patient;
               this.patient = null;
               oldPatient.RemoveInpatientTreatment(this);
            }
            if (newPatient != null)
            {
               this.patient = newPatient;
               this.patient.AddInpatientTreatment(this);
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
               oldRooms.RemoveInpatientTreatment(this);
            }
            if (newRooms != null)
            {
               this.rooms = newRooms;
               this.rooms.AddInpatientTreatment(this);
            }
         }
      }
   
      private int Id;
   
   }
}