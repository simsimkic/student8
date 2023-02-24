/***********************************************************************
 * Module:  ExaminationService.cs
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Repo;
using System;
using System.Collections.Generic;

namespace Service
{
   public class ExaminationService
   {

        
       public ExaminationService(ExaminationRepository er)
        {
            examinationRepository = er;
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            return examinationRepository.GetAllFreeAppointmentsByDoctorID(id, shift, dates);
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            return examinationRepository.GetAllTakenAppointmentsByRoomID(id);
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            return examinationRepository.GetFreeDoctorsByDateOfExamination(dateToCheck);
        }

        public ExaminationDto ScheduleSpecialistExamination(ExaminationDto examinationInfos)
        {
         // TODO: implement
         return null;
        }
      
      public ExaminationDto ScheduleRecheck(ExaminationDto examinationInfos)
      {
         // TODO: implement
         return null;
      }
      
      public ExaminationDto GetExamination(ExaminationDto exam)
      {
            return examinationRepository.GetExamination(exam);
      }
      
      public ExaminationDto CancelExamination(ExaminationDto exam)
      {
            return examinationRepository.DeleteExamination(exam);
      }
      
      public ExaminationDto ChangeRoomOfExamination(ExaminationDto oldExam, int newRoom)
      {

            return examinationRepository.ChangeExaminationRoom(oldExam, newRoom);
      }
      
      public ExaminationDto ScheduleExamination(ExaminationDto examinationInfos)
      {

            return examinationRepository.SaveExamination(examinationInfos);
      }
      
      public ExaminationDto ChangeTimeOfExamination(ExaminationDto oldExamination, DateTime newDate)
      {
            return examinationRepository.ChangeExaminationTime(oldExamination, newDate);
      }

        public List<ExaminationDto> GetAllExaminationSchedule()
        {
            return examinationRepository.GetAllExaminations();
        }

        public Repo.ExaminationRepository examinationRepository;
   
   }
}