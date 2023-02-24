using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Exceptions
{
    public class UsernameAlreadyExistException : SystemException
    {
        public UsernameAlreadyExistException(string e) : base(e)
        {

        }
    }
}
