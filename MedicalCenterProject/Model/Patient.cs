/***********************************************************************
 * Module:  Pacijent.cs
 * Purpose: Definition of the Class Pacijent
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Patient : User
   {
      public List<Patient>[] PatientList()
      {
         // TODO: implement
         return null;
      }
      
      public Patient ChangeProfileData(Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public void ProfileOverview(int patientId)
      {
         // TODO: implement
      }
   
      public MedicalRecord medicalRecord;
      public Reports[] reports;
      public SickBenefit sickBenefit;
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
            newInpatientTreatment.SetPatient(this);      
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
               oldInpatientTreatment.SetPatient((Patient)null);
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
               oldInpatientTreatment.SetPatient((Patient)null);
            tmpInpatientTreatment.Clear();
         }
      }
      public System.Collections.ArrayList chooseDoctor;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetChooseDoctor()
      {
         if (chooseDoctor == null)
            chooseDoctor = new System.Collections.ArrayList();
         return chooseDoctor;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetChooseDoctor(System.Collections.ArrayList newChooseDoctor)
      {
         RemoveAllChooseDoctor();
         foreach (ChoosenDoctor oChooseDoctor in newChooseDoctor)
            AddChooseDoctor(oChooseDoctor);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddChooseDoctor(ChoosenDoctor newChooseDoctor)
      {
         if (newChooseDoctor == null)
            return;
         if (this.chooseDoctor == null)
            this.chooseDoctor = new System.Collections.ArrayList();
         if (!this.chooseDoctor.Contains(newChooseDoctor))
            this.chooseDoctor.Add(newChooseDoctor);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveChooseDoctor(ChoosenDoctor oldChooseDoctor)
      {
         if (oldChooseDoctor == null)
            return;
         if (this.chooseDoctor != null)
            if (this.chooseDoctor.Contains(oldChooseDoctor))
               this.chooseDoctor.Remove(oldChooseDoctor);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllChooseDoctor()
      {
         if (chooseDoctor != null)
            chooseDoctor.Clear();
      }
      public MedicalCenter medicalCenter;
   
      private int Id;
      private Priority ChosenPriority;
   
   }
}