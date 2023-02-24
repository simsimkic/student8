/***********************************************************************
 * Module:  FeedbackRepository.cs
 * Purpose: Definition of the Class Repository.FeedbackRepository
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using MedicalCenterProject.Repo.ImplementedInFiles;
using Model;
using System;

namespace Repo
{
   public class FeedbackRepository
   {
      private string fileName;
      private ISaveInMemory<FeedbackDto> implementedRepo;
      public FeedbackRepository(string filename)
        {
            fileName = filename;
            MakeInstance(fileName);
        }

        public void MakeInstance(string filename)
        {
            if(implementedRepo == null) { implementedRepo = new FeedbackImplementedRepo(fileName); }
        }

        

        public FeedbackDto SaveFeedback(FeedbackDto newFeedback)
        {
            implementedRepo.Create(newFeedback);
            return newFeedback;
         }


   
   }
}