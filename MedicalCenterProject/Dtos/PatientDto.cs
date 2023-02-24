using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Dtos
{
    public class PatientDto
    {
        private int iD;
        private string name;
        private string surname;
        private string email;
        private string username;
        private string password;
        private string jmbg;

        public PatientDto()
        {
        }

        public PatientDto(int iD, string name, string surname, string email, string username, string password, string jmbg)
        {
            this.iD = iD;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.username = username;
            this.password = password;
            this.jmbg = jmbg;
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
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
        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }
    }
}
