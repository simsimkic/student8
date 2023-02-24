/***********************************************************************
 * Module:  UserService.cs
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/


using Model;
using Repo;
using System;
using MedicalCenterProject.Dtos;

namespace Service
{
    public class UserService
   {
        public Repo.UsersRepository usersRepository;

        public UserService(UsersRepository ru)
        {
            usersRepository = ru;
        }
        public UserDto RegisterUser(UserDto newUser)
        {
            return usersRepository.SaveUser(newUser);
        }
      
        public string ValidateLogIn(string username, string password)
        {
            return usersRepository.ValidateLogInData(username, password);
        }

        public bool ValidateRegister(UserDto newUser)
        {
            usersRepository.ValidateRegistrationData(newUser);
            return true;
        }

        public string ChangePassword(string username, string newPassword)
        {
            return usersRepository.ChangePassword(username, newPassword);
        }

    }
}