/***********************************************************************
 * Module:  FaqRepository.cs
 * Purpose: Definition of the Class Repository.FaqRepository
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using MedicalCenterProject.Repo.ImplementedInFiles;
using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repo
{
   public class FaqRepository
   {
      private string filename;
      private ISaveInMemory<FaqDto> implementedRepo;

        public FaqRepository(string filename)
        {
            this.filename = filename;
            MakeInstance(filename);
        }

        public void MakeInstance(string usersFile)
        {
            if (implementedRepo == null) { implementedRepo = new FaqImplementedRepo(usersFile); }
        }

        public Faq GetFAQ(Faq question)
        {
         // TODO: implement
         return null;
        }
      
      public FaqDto SaveFaq(FaqDto faq)
      {
            return implementedRepo.Update(faq, null);
      }
      
      public List<FaqDto> GetUnansweredQuestions()
      {
            return implementedRepo.GetAll();
      }

        public FaqDto SaveQuestion(FaqDto question)
        {
            return implementedRepo.Create(question);
        }

    }
}