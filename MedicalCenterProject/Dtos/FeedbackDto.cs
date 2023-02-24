using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Dtos
{
  
    public class FeedbackDto
    {
        private int iD;
        private string content;

        public FeedbackDto(int iD, string content)
        {
            this.iD = iD;
            this.content = content;
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }

    
}
