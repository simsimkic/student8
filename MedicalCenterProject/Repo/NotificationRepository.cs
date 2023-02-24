/***********************************************************************
 * Module:  NotificationRepository.cs
 * Purpose: Definition of the Class Repo.NotificationRepository
 ***********************************************************************/

using MedicalCenterProject.Dtos;
using MedicalCenterProject.Repo.ImplementedInFiles;
using Model;
using System;
using System.Collections.Generic;

namespace Repo
{
   public class NotificationRepository
   {
      private string filename;
      private ISaveInMemory<NotificationDto> notification;

      public NotificationRepository(string filename)
      {
         this.filename = filename;
         MakeInstance();
      }

      private void MakeInstance()
        {
            if (notification == null) notification = new NotificationImplementedRepo(filename);
        }
      public NotificationDto SaveNotification(NotificationDto newNotification)
      {
            return notification.Create(newNotification);
      }

        public List<NotificationDto> GetAllNotifications()
        {
            return notification.GetAll();
        }

    }
}