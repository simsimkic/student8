/***********************************************************************
 * Module:  ExaminationRepository.cs
 * Purpose: Definition of the Class Repository.ExaminationRepository
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using MedicalCenterProject.Exceptions;
using MedicalCenterProject.Repo.ImplementedInFiles;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Repo
{
   public class ExaminationRepository
   {
        private string examinationFile;
        private string separator;
        private string roomOccupationFile;
        private ISaveInMemory<ExaminationDto> examinations;

        
      public ExaminationRepository(string examinationFile, string separator, string roomOccupationFile)
        {
            this.examinationFile = examinationFile;
            this.separator = separator;
            this.roomOccupationFile = roomOccupationFile;
            MakeInstance();
        }

        private void MakeInstance()
        {
            if (examinations == null) examinations = new ExaminationImplementedRepo(examinationFile, separator, roomOccupationFile);
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id,string shift, List<DateTime> dates)
        {
            return examinations.GetAllFreeAppointmentsByDoctorID(id, shift, dates);
        }

        public ExaminationDto ChangeExaminationTime(ExaminationDto oldExamination, DateTime newDate)
        {
            ExaminationDto oldExam = examinations.GetByIDAndDate(oldExamination.DoctorID, oldExamination.Date);
            if(oldExam == null) { throw new ExaminationDoesntExistException("Examination doesnt exist."); }
            ExaminationDto newExam = new ExaminationDto(newDate);
            ExaminationDto fullNewExam = examinations.Update(oldExam, newExam);
            return fullNewExam;
        }


        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            return examinations.GetFreeDoctorsByDateOfExamination(dateToCheck);
        }
         
        public ExaminationDto ChangeExaminationRoom(ExaminationDto oldExamination,int newRoom)
        {
            ExaminationDto oldExam = examinations.GetByIDAndDate(oldExamination.DoctorID, oldExamination.Date);
            if (oldExam == null) { throw new ExaminationDoesntExistException("Examination doesnt exist."); }
            ExaminationDto newExam = new ExaminationDto(newRoom);
            ExaminationDto fullNewExam = examinations.Update(oldExam, newExam);
            return fullNewExam;
        }

      public ExaminationDto SaveExamination(ExaminationDto examination)
      {
          return examinations.Create(examination);
      }
      
      public ExaminationDto GetExamination(ExaminationDto exam)
      {
            return examinations.GetByIDAndDate(exam.DoctorID, exam.Date);      }
      
      public ExaminationDto DeleteExamination(ExaminationDto exam)
      {
            return examinations.Delete(exam);
      }

      public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            return examinations.GetAllTakenAppointmentsByRoomID(id);
        }

        public List<ExaminationDto> GetAllExaminations()
        {
            return examinations.GetAll();
        }


    }
}