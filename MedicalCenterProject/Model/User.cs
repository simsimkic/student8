/***********************************************************************
 * Module:  Korisnik.cs
 * Purpose: Definition of the Class Korisnik
 ***********************************************************************/

using System;

namespace Model
{
   public class User
   {
      public void SignIn(String username, String password)
      {
         // TODO: implement
      }
      
      public User RegisterUser(User newUser)
      {
         // TODO: implement
         return null;
      }
   
      public Feedback feedback;
   
      private String Name;
      private String Surname;
      private String UserName;
      private String Password;
      private String Email;
   
   }
}