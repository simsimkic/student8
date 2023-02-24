/***********************************************************************
 * Module:  FaqService.cs
 * Purpose: Definition of the Class Service.FaqService
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Repo;
using System;
using System.Collections.Generic;

namespace Service
{
   public class FaqService
   {
      public FaqService(FaqRepository fr)
        {
            faqRepository = fr;
        }

        public FaqDto LeaveQuestion(FaqDto question)
        {
            return faqRepository.SaveQuestion(question);
        }

        public FaqDto AddFAQ(FaqDto faq)
      {
            return faqRepository.SaveFaq(faq);
      }
        public List<FaqDto> GetUnansweredQuestions()
        {
            return faqRepository.GetUnansweredQuestions();
        }

        public Repo.FaqRepository faqRepository;
   
   }
}