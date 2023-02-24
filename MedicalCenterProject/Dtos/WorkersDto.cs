using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Dtos
{
    public class WorkersDto
    {
        private int iD;
        private string name;
        private string surname;
        private string email;
        private string username;
        private string password;
        private string workplace;
        private string shift;

        public WorkersDto(int iD, string name, string surname, string email, string username, string password, string workplace,string shift)
        {
            this.iD = iD;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.username = username;
            this.password = password;
            this.workplace = workplace;
            this.shift = shift;
        }
        
        public WorkersDto() { }

        public string Shift
        {
            get { return shift; }
            set { shift = value; }            
        }
        public int ID
        {
            get { return iD; }
            set { iD = value ; }
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
        public string Workplace
        {
            get { return workplace; }
            set { workplace = value; }
        }

    }


}
