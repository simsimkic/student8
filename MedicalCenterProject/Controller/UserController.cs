/***********************************************************************
 * Module:  UserController.cs
 * Purpose: Definition of the Class Controller.UserController
 ***********************************************************************/

using Service;
using System;
using MedicalCenterProject.Dtos;
using Model;

namespace Controller
{
    public class UserController
    {
        public Service.UserService userService;
        public UserDto RegisterUser(UserDto newUser)
        {
            try
            {
                userService.ValidateRegister(newUser);

            } catch(Exception e) { return null; }

            return userService.RegisterUser(newUser);
        }

        public string SignIn(String username, String password)
        {
            try
            {
                return userService.ValidateLogIn(username, password);
            } catch(Exception e)
            {
                return "Wrong username or password";
            }
        }
    
        public string ChangePassword(string username, string newPassword)
        {
            try
            {
                return userService.ChangePassword(username, newPassword);
            } catch(Exception e) { return null; }
        }

        public UserController(UserService userService)
        {
            this.userService = userService;
        }
    }
}