/***********************************************************************
 * Module:  Prostorije.cs
 * Purpose: Definition of the Class Prostorije
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Rooms
   {
      public List<Rooms>[] RoomsOverview()
      {
         // TODO: implement
         return null;
      }
   
      public System.Collections.ArrayList examination;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetExamination()
      {
         if (examination == null)
            examination = new System.Collections.ArrayList();
         return examination;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetExamination(System.Collections.ArrayList newExamination)
      {
         RemoveAllExamination();
         foreach (Examination oExamination in newExamination)
            AddExamination(oExamination);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddExamination(Examination newExamination)
      {
         if (newExamination == null)
            return;
         if (this.examination == null)
            this.examination = new System.Collections.ArrayList();
         if (!this.examination.Contains(newExamination))
         {
            this.examination.Add(newExamination);
            newExamination.SetRooms(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveExamination(Examination oldExamination)
      {
         if (oldExamination == null)
            return;
         if (this.examination != null)
            if (this.examination.Contains(oldExamination))
            {
               this.examination.Remove(oldExamination);
               oldExamination.SetRooms((Rooms)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllExamination()
      {
         if (examination != null)
         {
            System.Collections.ArrayList tmpExamination = new System.Collections.ArrayList();
            foreach (Examination oldExamination in examination)
               tmpExamination.Add(oldExamination);
            examination.Clear();
            foreach (Examination oldExamination in tmpExamination)
               oldExamination.SetRooms((Rooms)null);
            tmpExamination.Clear();
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
            newRenovation.SetRooms(this);      
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
               oldRenovation.SetRooms((Rooms)null);
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
               oldRenovation.SetRooms((Rooms)null);
            tmpRenovation.Clear();
         }
      }
      public Operation operation;
      public System.Collections.ArrayList inpatientTreatment;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetInpatientTreatment()
      {
         if (inpatientTreatment == null)
            inpatientTreatment = new System.Collections.ArrayList();
         return inpatientTreatment;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetInpatientTreatment(System.Collections.ArrayList newInpatientTreatment)
      {
         RemoveAllInpatientTreatment();
         foreach (InpatientTreatment oInpatientTreatment in newInpatientTreatment)
            AddInpatientTreatment(oInpatientTreatment);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddInpatientTreatment(InpatientTreatment newInpatientTreatment)
      {
         if (newInpatientTreatment == null)
            return;
         if (this.inpatientTreatment == null)
            this.inpatientTreatment = new System.Collections.ArrayList();
         if (!this.inpatientTreatment.Contains(newInpatientTreatment))
         {
            this.inpatientTreatment.Add(newInpatientTreatment);
            newInpatientTreatment.SetRooms(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveInpatientTreatment(InpatientTreatment oldInpatientTreatment)
      {
         if (oldInpatientTreatment == null)
            return;
         if (this.inpatientTreatment != null)
            if (this.inpatientTreatment.Contains(oldInpatientTreatment))
            {
               this.inpatientTreatment.Remove(oldInpatientTreatment);
               oldInpatientTreatment.SetRooms((Rooms)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllInpatientTreatment()
      {
         if (inpatientTreatment != null)
         {
            System.Collections.ArrayList tmpInpatientTreatment = new System.Collections.ArrayList();
            foreach (InpatientTreatment oldInpatientTreatment in inpatientTreatment)
               tmpInpatientTreatment.Add(oldInpatientTreatment);
            inpatientTreatment.Clear();
            foreach (InpatientTreatment oldInpatientTreatment in tmpInpatientTreatment)
               oldInpatientTreatment.SetRooms((Rooms)null);
            tmpInpatientTreatment.Clear();
         }
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
               oldMedicalCenter.RemoveRooms(this);
            }
            if (newMedicalCenter != null)
            {
               this.medicalCenter = newMedicalCenter;
               this.medicalCenter.AddRooms(this);
            }
         }
      }
   
      private int RoomId;
   
   }
}