/***********************************************************************
 * Module:  Pregled.cs
 * Purpose: Definition of the Class Pregled
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Examination
   {
      public Examination ChangeRoomOfExamination(int newRoomId, int examinationId)
      {
         // TODO: implement
         return null;
      }
      
      public Examination CancelExamination(int examinationId)
      {
         // TODO: implement
         return null;
      }
      
      public Examination ScheduleSpecialistExamination(Examination examinationInfos)
      {
         // TODO: implement
         return null;
      }
      
      public List<Examination>[] ScheduledExaminations()
      {
         // TODO: implement
         return null;
      }
      
      public Examination ScheduleRecheck(Examination examinationInfos)
      {
         // TODO: implement
         return null;
      }
      
      public Examination ScheduleExamination(Examination examinationInfos)
      {
         // TODO: implement
         return null;
      }
      
      public Examination ChangeTimeOfExamination(DateTime newTime, int examinationId)
      {
         // TODO: implement
         return null;
      }
      
      public Examination SendNotification(Examination changedExaminationData)
      {
         // TODO: implement
         return null;
      }
   
      public MedicalRecord medicalRecord;
      public Medicine[] medicine;
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
               oldRooms.RemoveExamination(this);
            }
            if (newRooms != null)
            {
               this.rooms = newRooms;
               this.rooms.AddExamination(this);
            }
         }
      }
      public Doctor doctor;
   
      private DateTime Date;
   
   }
}