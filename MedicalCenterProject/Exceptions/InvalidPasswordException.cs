using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCenterProject.Exceptions
{
    class InvalidPasswordException : SystemException
    {
        public InvalidPasswordException(string e) : base(e)
        {
            
        }
    }
}
