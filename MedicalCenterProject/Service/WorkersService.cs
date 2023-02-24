/***********************************************************************
 * Module:  WorkersService.cs
 * Purpose: Definition of the Class Service.WorkersService
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Repo;
using System;
using System.Collections.Generic;

namespace Service
{
   public class WorkersService
   {

      public WorkersService(WorkersRepository wr)
        {
            workersRepository = wr;
        }
      public List<WorkersDto> GetWorkers()
        {
            return workersRepository.GetAllDoctors();
        } 

      public WorkersDto RegisterWorkers(User newWorkerData, WorkPlace workPlace)
      {
         // TODO: implement
         return null;
      }
      
      public bool IsUsernameValid(String username)
      {
         // TODO: implement
         return false;
      }
      
      public bool IsEmailValid(String email)
      {
         // TODO: implement
         return false;
      }

        public int GetUserId(string username, string password)
        {
            return workersRepository.GetUserId(username, password);
        }

        public Repo.WorkersRepository workersRepository;

        public string GetDoctorShift(string doctorId)
        {
            return workersRepository.GetDoctorShift(doctorId);
        }

        public WorkersDto RegisterWorkers(WorkersDto newWorker)
        {
            return workersRepository.SaveWorker(newWorker);
        }

    }
}