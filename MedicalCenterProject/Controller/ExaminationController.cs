/***********************************************************************
 * Module:  ExaminationController.cs
 * Purpose: Definition of the Class Controller.ExaminationController
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class ExaminationController
   {
        public ExaminationController(ExaminationService es)
        {
            examinationService = es;
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            return examinationService.GetAllFreeAppointmentsByDoctorID(id, shift, dates);
        }

      public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            return examinationService.GetAllTakenAppointmentsByRoomID(id);
        }

        public ExaminationDto ScheduleRecheck(ExaminationDto examinationInfos)
      {
         // TODO: implement
         return null;
      }
      
      public ExaminationDto GetExamination(ExaminationDto exam)
      {
            return examinationService.GetExamination(exam);
      }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            return examinationService.GetFreeDoctorsByDateOfExamination(dateToCheck);
        }


        public ExaminationDto CancelExamination(ExaminationDto exam)
        {
            try
            {
                return examinationService.CancelExamination(exam);
            } catch(Exception e)
            {
                return null;
            }
          }
      
      public Examination ScheduleSpecialistExamination(Examination examinationInfos)
      {
         // TODO: implement
         return null;
      }
      
      public ExaminationDto ChangeRoomOfExamination(ExaminationDto oldExam, int newRoom)
      {
            return examinationService.ChangeRoomOfExamination(oldExam, newRoom);
        
      }
      
      public ExaminationDto ScheduleExamination(ExaminationDto examinationInfos)
      {
            return examinationService.ScheduleExamination(examinationInfos);
      }
      
      public ExaminationDto ChangeTimeOfExamination(ExaminationDto oldExamination, DateTime newDate)
      {
            try
            {
                return examinationService.ChangeTimeOfExamination(oldExamination, newDate);
            } catch(Exception) { return null; }
      }

        public List<ExaminationDto> ListOfScheduledExaminations()
        {
            return examinationService.GetAllExaminationSchedule();
        }


        public Service.ExaminationService examinationService;
   
   }
}