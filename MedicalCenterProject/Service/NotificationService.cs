/***********************************************************************
 * Module:  NotificationService.cs
 * Purpose: Definition of the Class Service.NotificationService
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Repo;
using System;
using System.Collections.Generic;

namespace Service
{
   public class NotificationService
   {
      public NotificationService(NotificationRepository nr)
        {
            notificationRepository = nr;
        }
      public NotificationDto SendNotification(NotificationDto newNotification)
      {
            return notificationRepository.SaveNotification(newNotification);
          
      }

        public List<NotificationDto> GetAllNotifications()
        {
            return notificationRepository.GetAllNotifications();
        }

        public Repo.NotificationRepository notificationRepository;
   
   }
}