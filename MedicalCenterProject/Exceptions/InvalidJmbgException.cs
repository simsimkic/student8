using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Exceptions
{
    class InvalidJmbgException : SystemException
    {
        public InvalidJmbgException(string e) : base(e)
        {

        }
    }
}
