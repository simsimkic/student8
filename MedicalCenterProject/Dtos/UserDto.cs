using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MedicalCenterProject.Dtos
{
    public class UserDto
    {
        private string name;
        private string surname;
        private string email;
        private string username;
        private string password;
        private string role;
        private string jmbg;

        public UserDto(string name, string surname, string email, string username, string password, string role, string jmbg)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.username = username;
            this.password = password;
            this.role = role;
            this.jmbg = jmbg;
        }

        public UserDto(string username, string newPassword)
        {
            this.username = username;
            this.password = newPassword;
        }

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }
        public string Role
        {
            get { return role;}
            set { name = value;}
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
