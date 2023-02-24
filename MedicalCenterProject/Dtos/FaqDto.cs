using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Dtos
{
    public class FaqDto
    {
        private string question;
        private string answer;

        public FaqDto(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }

        public string Question
        {
            get { return question; }
            set { question = value;  }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}
