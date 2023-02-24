/***********************************************************************
 * Module:  SendNotificationController.cs
 * Purpose: Definition of the Class Controller.SendNotificationController
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class NotificationController
   {
      public NotificationController(NotificationService ns)
        {
            notificationService = ns;
        }

      public NotificationDto SendNotification(NotificationDto newNotification)
      {
            return notificationService.SendNotification(newNotification);
      }

        public List<NotificationDto> GetAllNotifications()
        {
            return notificationService.GetAllNotifications();
        }

        public Service.NotificationService notificationService;
   
   }
}