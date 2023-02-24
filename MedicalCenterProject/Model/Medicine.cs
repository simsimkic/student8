/***********************************************************************
 * Module:  Lek.cs
 * Purpose: Definition of the Class Lek
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Medicine
   {
      public Medicine PrescriptMedicine(Patient patient, Medicine medicine)
      {
         // TODO: implement
         return null;
      }
      
      public Medicine ChangeMedicine(Medicine medicine)
      {
         // TODO: implement
         return null;
      }
      
      public Medicine MedicineValidation(Medicine medicine)
      {
         // TODO: implement
         return null;
      }
      
      public Medicine MedicineReview()
      {
         // TODO: implement
         return null;
      }
      
      public Medicine MedicineDataUpdate(Medicine medicine)
      {
         // TODO: implement
         return null;
      }
      
      public Medicine AddMedicine(Medicine medicine)
      {
         // TODO: implement
         return null;
      }
      
      public List<Medicine>[] MedicineQuantity()
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
            this.examination.Add(newExamination);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveExamination(Examination oldExamination)
      {
         if (oldExamination == null)
            return;
         if (this.examination != null)
            if (this.examination.Contains(oldExamination))
               this.examination.Remove(oldExamination);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllExamination()
      {
         if (examination != null)
            examination.Clear();
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
               oldMedicalCenter.RemoveMedicine(this);
            }
            if (newMedicalCenter != null)
            {
               this.medicalCenter = newMedicalCenter;
               this.medicalCenter.AddMedicine(this);
            }
         }
      }
   
      private int Id;
      private String Name;
      private int Quantity;
      private String Structure;
      private String Type;
      private bool Approved = false;
   
   }
}