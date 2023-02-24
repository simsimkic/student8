/***********************************************************************
 * Module:  FaqController.cs
 * Purpose: Definition of the Class Controller.FaqController
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class FaqController
   {
      public FaqController(FaqService fs)
        {
            faqService = fs;
        }

      public FaqDto AddFAQ(FaqDto faq)
      {
            return faqService.AddFAQ(faq);
      }
      
      public FaqDto LeaveQuestion(FaqDto question)
      {
            return faqService.LeaveQuestion(question);
        }

      public List<FaqDto> GetUnansweredQuestions()
        {
            return faqService.GetUnansweredQuestions();
        }
   
      public Service.FaqService faqService;
   
   }
}