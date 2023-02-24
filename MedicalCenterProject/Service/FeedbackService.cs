/***********************************************************************
 * Module:  FeedbackService.cs
 * Purpose: Definition of the Class Service.FeedbackService
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Repo;
using System;

namespace Service
{
   public class FeedbackService
   {
      public FeedbackDto LeaveFeedback(FeedbackDto feedback)
      {
            return feedbackRepository.SaveFeedback(feedback);
      }
   
      public Repo.FeedbackRepository feedbackRepository;
      
      public FeedbackService(FeedbackRepository fr)
        {
            feedbackRepository = fr;
        }
   }
}