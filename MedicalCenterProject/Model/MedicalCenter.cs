/***********************************************************************
 * Module:  ZdravstveniCentar.cs
 * Purpose: Definition of the Class ZdravstveniCentar
 ***********************************************************************/

using System;

namespace Model
{
   public class MedicalCenter
   {
      public Manager manager;
      public System.Collections.ArrayList rooms;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetRooms()
      {
         if (rooms == null)
            rooms = new System.Collections.ArrayList();
         return rooms;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRooms(System.Collections.ArrayList newRooms)
      {
         RemoveAllRooms();
         foreach (Rooms oRooms in newRooms)
            AddRooms(oRooms);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddRooms(Rooms newRooms)
      {
         if (newRooms == null)
            return;
         if (this.rooms == null)
            this.rooms = new System.Collections.ArrayList();
         if (!this.rooms.Contains(newRooms))
         {
            this.rooms.Add(newRooms);
            newRooms.SetMedicalCenter(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveRooms(Rooms oldRooms)
      {
         if (oldRooms == null)
            return;
         if (this.rooms != null)
            if (this.rooms.Contains(oldRooms))
            {
               this.rooms.Remove(oldRooms);
               oldRooms.SetMedicalCenter((MedicalCenter)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllRooms()
      {
         if (rooms != null)
         {
            System.Collections.ArrayList tmpRooms = new System.Collections.ArrayList();
            foreach (Rooms oldRooms in rooms)
               tmpRooms.Add(oldRooms);
            rooms.Clear();
            foreach (Rooms oldRooms in tmpRooms)
               oldRooms.SetMedicalCenter((MedicalCenter)null);
            tmpRooms.Clear();
         }
      }
      public System.Collections.ArrayList renovation;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetRenovation()
      {
         if (renovation == null)
            renovation = new System.Collections.ArrayList();
         return renovation;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRenovation(System.Collections.ArrayList newRenovation)
      {
         RemoveAllRenovation();
         foreach (Renovation oRenovation in newRenovation)
            AddRenovation(oRenovation);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddRenovation(Renovation newRenovation)
      {
         if (newRenovation == null)
            return;
         if (this.renovation == null)
            this.renovation = new System.Collections.ArrayList();
         if (!this.renovation.Contains(newRenovation))
         {
            this.renovation.Add(newRenovation);
            newRenovation.SetMedicalCenter(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveRenovation(Renovation oldRenovation)
      {
         if (oldRenovation == null)
            return;
         if (this.renovation != null)
            if (this.renovation.Contains(oldRenovation))
            {
               this.renovation.Remove(oldRenovation);
               oldRenovation.SetMedicalCenter((MedicalCenter)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllRenovation()
      {
         if (renovation != null)
         {
            System.Collections.ArrayList tmpRenovation = new System.Collections.ArrayList();
            foreach (Renovation oldRenovation in renovation)
               tmpRenovation.Add(oldRenovation);
            renovation.Clear();
            foreach (Renovation oldRenovation in tmpRenovation)
               oldRenovation.SetMedicalCenter((MedicalCenter)null);
            tmpRenovation.Clear();
         }
      }
      public System.Collections.ArrayList medicine;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetMedicine()
      {
         if (medicine == null)
            medicine = new System.Collections.ArrayList();
         return medicine;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetMedicine(System.Collections.ArrayList newMedicine)
      {
         RemoveAllMedicine();
         foreach (Medicine oMedicine in newMedicine)
            AddMedicine(oMedicine);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddMedicine(Medicine newMedicine)
      {
         if (newMedicine == null)
            return;
         if (this.medicine == null)
            this.medicine = new System.Collections.ArrayList();
         if (!this.medicine.Contains(newMedicine))
         {
            this.medicine.Add(newMedicine);
            newMedicine.SetMedicalCenter(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveMedicine(Medicine oldMedicine)
      {
         if (oldMedicine == null)
            return;
         if (this.medicine != null)
            if (this.medicine.Contains(oldMedicine))
            {
               this.medicine.Remove(oldMedicine);
               oldMedicine.SetMedicalCenter((MedicalCenter)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllMedicine()
      {
         if (medicine != null)
         {
            System.Collections.ArrayList tmpMedicine = new System.Collections.ArrayList();
            foreach (Medicine oldMedicine in medicine)
               tmpMedicine.Add(oldMedicine);
            medicine.Clear();
            foreach (Medicine oldMedicine in tmpMedicine)
               oldMedicine.SetMedicalCenter((MedicalCenter)null);
            tmpMedicine.Clear();
         }
      }
      public Doctor[] doctor;
      public Patient[] patient;
      public Secretary secretary;
   
      private String Name;
   
   }
}