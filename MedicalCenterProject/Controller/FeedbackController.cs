/***********************************************************************
 * Module:  FeedbackController.cs
 * Purpose: Definition of the Class Controller.FeedbackController
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Model;
using Service;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Controller
{
   public class FeedbackController
   {
      public FeedbackDto LeaveFeedback(FeedbackDto feedback)
      {
            return feedbackService.LeaveFeedback(feedback);
      }
   
      public Service.FeedbackService feedbackService;
   
      public FeedbackController(FeedbackService fs)
        {
            feedbackService = fs;
        }
   }
}