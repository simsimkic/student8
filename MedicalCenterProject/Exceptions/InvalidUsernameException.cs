using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCenterProject.Exceptions
{
    public class InvalidUsernameException : SystemException
    {
        public InvalidUsernameException(string e) : base()
        {
            
        }
    }
}
