using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Exceptions
{
    class NothingToReadFromFileException : SystemException
    {
        public NothingToReadFromFileException(string e) : base(e)
        {

        }
    }
}
