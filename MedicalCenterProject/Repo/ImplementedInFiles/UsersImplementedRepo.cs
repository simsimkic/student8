using MedicalCenterProject.Dtos;
using MedicalCenterProject.Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace MedicalCenterProject.Repo.Abstract
{
    public class UsersImplementedRepo : ISaveInMemory<UserDto>
{
    private string _userFile;
    private string _separator;
    private string _patientsFile;
        
    public UsersImplementedRepo(string userFile,string separator, string patientsFile)
    {
        _userFile = userFile;
        _separator = separator;
        _patientsFile = patientsFile;
    }

    public UserDto Create(UserDto entity)
    {
        return SaveUser(entity);
    }

    public UserDto Delete(UserDto entity)
    {
        throw new NotImplementedException();
    }

    public UserDto Update(UserDto entity, UserDto none)
    {
        UserDto user = GetByUsername(entity.Username);
        if (user == null) throw new AccauntDoesntExistException("Accaunt not found");
        string allTextFromFile = ConvertFileToString();
        
        allTextFromFile = allTextFromFile.Replace(userFromFile(user), userToReplace(user,entity));
        File.WriteAllText(_userFile, allTextFromFile);
        return user;
    }

    private string userFromFile(UserDto user)
    {
            return user.Name + _separator + user.Surname + _separator +
           user.Email + _separator + user.Username + _separator + user.Password +
           _separator + user.Role + _separator + user.Jmbg;
    }
    private string userToReplace(UserDto user,UserDto entity)
    {
            return user.Name + _separator + user.Surname + _separator +
           user.Email + _separator + user.Username + _separator + entity.Password.GetHashCode()+
           _separator + user.Role + _separator + user.Jmbg;
    }

    public string ConvertFileToString()
    {
        return File.ReadAllText(_userFile);
        
    }

        public UserDto GetByUsername(string username)
    {
        UserDto user = GetUserData(username);
        return user;
    }
    public UserDto GetUserData(string username)
       {
            return GetUserByUsername(username, ReadFile(_userFile));
       }

    public string[] ReadFile(string _userFile)
      {  
            string[] lines = File.ReadAllLines(_userFile).ToArray();
            return lines;       
      }

    public UserDto GetUserByUsername(string username, string[] lines)
        {
            if (lines.Length != 0)
            {
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    if (username == entries[3]) return ConvertStringToObject(entries);
                }
            }
            return null;
        }

      public UserDto SaveUser(UserDto newUser)
        {
            WriteLineToFile(newUser);
            return newUser;
        }


        private UserDto ConvertStringToObject(string[] userFromFile)
        {
            UserDto user = new UserDto(userFromFile[0], userFromFile[1], userFromFile[2], userFromFile[3], userFromFile[4], userFromFile[5], userFromFile[6]);
            return user;
        }

        private string ConvertObjectUserToString(UserDto newUser)
        {
            string userDataString = newUser.Name + _separator + newUser.Surname + _separator +
            newUser.Email + _separator + newUser.Username + _separator + newUser.Password.GetHashCode() +
            _separator + newUser.Role + _separator + newUser.Jmbg;
            return userDataString;
        }

        private string ConvertObjectPatientToString(UserDto newUser)
        {
            string userDataString = newUser.Name + _separator + newUser.Surname + _separator +
            newUser.Email + _separator + newUser.Username + _separator + newUser.Password.GetHashCode() +
            _separator + newUser.Jmbg;
            return userDataString;
        }

        private void WriteLineToFile(UserDto newUser)
        {
            int patientID = File.ReadAllLines(_patientsFile).Length + 1;
            File.AppendAllText(_userFile, ConvertObjectUserToString(newUser) + Environment.NewLine);
            File.AppendAllText(_patientsFile, patientID.ToString()+_separator+ ConvertObjectPatientToString(newUser) + Environment.NewLine);
        }

        public UserDto GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetByNameAndSurname()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllFreeAppointmentsByDoctorID(int id, string shift, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTakenAppointmentsByRoomID(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetByIDAndDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFreeDoctorsByDateOfExamination(DateTime dateToCheck)
        {
            throw new NotImplementedException();
        }

        public UserDto GetByJMBG(string jmbg)
        {
            throw new NotImplementedException();
        }

        public MedicineDto ValidateMedicine(string medicine)
        {
            throw new NotImplementedException();
        }

        public List<MedicineDto> GetAllMedicine()
        {
            throw new NotImplementedException();
        }

        public MedicineDto GetMedicineByName(string medicine)
        {
            throw new NotImplementedException();
        }
    }
}
