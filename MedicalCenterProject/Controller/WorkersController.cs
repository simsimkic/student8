/***********************************************************************
 * Module:  WorkersController.cs
 * Purpose: Definition of the Class Controller.WorkersController
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class WorkersController
   {
      public WorkersController(WorkersService ws)
        {
            workersService = ws;
        }

      public List<WorkersDto> GetWorkers()
        {
            return workersService.GetWorkers();
        }

      public WorkersDto RegisterWorkers(User newWorkerData, WorkPlace workPlace)
      {
         // TODO: implement
         return null;
      }

        public int GetUserId(string username, string password)
        {
            try
            {
                return workersService.GetUserId(username, password);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public string GetDoctorShift(string doctorId)
        {
            return workersService.GetDoctorShift(doctorId);
        }

        public WorkersDto RegisterWorkers(WorkersDto newWorker)
        {
            return workersService.RegisterWorkers(newWorker);
        }

        public Service.WorkersService workersService;
   
   }
}