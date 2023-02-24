/***********************************************************************
 * Module:  RegisteredUsers.cs
 * Purpose: Definition of the Class Repository.RegisteredUsers
 ***********************************************************************/


using Model;
using MedicalCenterProject.Dtos;
using MedicalCenterProject.Repo.Abstract;
using MedicalCenterProject.Exceptions;
using System.Windows.Markup;

namespace Repo
{
    public class UsersRepository
    {
        private string users_file;
        private string separator;
        private string patients_file;
        private ISaveInMemory<UserDto> implementedRepo;

        public UsersRepository(string usersFile, string separator, string patients_file)
        {
            this.users_file = usersFile;
            this.separator = separator;
            this.patients_file = patients_file;
            MakeInstance(usersFile, separator);
        }

        
        public void MakeInstance(string usersFile, string separator)
        {
            if(implementedRepo == null) { implementedRepo =  new UsersImplementedRepo(usersFile, separator, patients_file);  }
        }

        public void ValidateRegistrationData(UserDto newUser)
        {
            UserDto user = implementedRepo.GetByUsername(newUser.Username);
            if (user != null) {
                if (user.Email == newUser.Email) throw new EmailAlreadyExistException("Email already exist.");
                else throw new UsernameAlreadyExistException("Username already exist.");
            }
        }

        public string ValidateLogInData(string username, string password)
        {
            UserDto user = implementedRepo.GetByUsername(username);
            if (user == null) { throw new InvalidUsernameException("Incorect username"); }
            else if (user.Password != password.GetHashCode().ToString()) throw new InvalidPasswordException("Incorect password");
            else return user.Role;
        }

        public string ChangePassword(string username, string newPassword)
        {
            UserDto oldUser = new UserDto(username, newPassword);
            implementedRepo.Update(oldUser, null);
            return oldUser.Password;
        }

        public UserDto SaveUser(UserDto newUser)
        {
           return implementedRepo.Create(newUser);
        }
    }
}
