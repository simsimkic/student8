/***********************************************************************
 * Module:  WorkersRepository.cs
 * Purpose: Definition of the Class Repository.WorkersRepository
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using MedicalCenterProject.Exceptions;
using MedicalCenterProject.Repo.ImplementedInFiles;
using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repo
{
   public class WorkersRepository
   {
      private string filename;
      private string separator;
      private string usersFilename;
      private ISaveInMemory<WorkersDto> workersMemory;

      public WorkersRepository(string filename, string separator, string usersFilename)
      {
            this.usersFilename = usersFilename;
            this.filename = filename;
            this.separator = separator;
            MakeInstance();
      }

      public void MakeInstance()
        {
            if (workersMemory == null) workersMemory = new WorkersImplementedRepo(filename, separator, usersFilename);
        }
      public List<WorkersDto> GetWorkerList()
      {
         // TODO: implement
         return null;
      }

        public WorkersDto SaveWorker(WorkersDto newWorker)
        {
            return workersMemory.Create(newWorker);
        }

        public List<WorkersDto> GetAllDoctors()
      {
          return workersMemory.GetAll();
      }
      
      public List<WorkersDto> GetAllSecretary()
      {
         // TODO: implement
         return null;
      }

        public int GetUserId(string username, string password)
        {
            WorkersDto user = workersMemory.GetByUsername(username);
            if (user == null) { throw new InvalidUsernameException("Incorect username"); }
            else if (user.Password != password.GetHashCode().ToString()) throw new InvalidPasswordException("Incorect password");
            else return user.ID;
        }

        public string GetDoctorShift(string doctorId)
        {
            WorkersDto user = workersMemory.GetByID(Int32.Parse(doctorId));
            if (user == null) { throw new InvalidIdException("Incorect id"); }
            return user.Shift;
        }

    }
}