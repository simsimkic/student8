using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Exceptions
{
    class InvalidIdException : SystemException
    {
        public InvalidIdException(string e) : base(e)
        {

        }
    }
}
