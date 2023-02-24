using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Dtos
{
    
    public class NotificationDto
    {
        private ExaminationDto oldExam;
        private ExaminationDto newExam;

        public NotificationDto(ExaminationDto oldExam, ExaminationDto newExam)
        {
            this.oldExam = oldExam;
            this.newExam = newExam;
        }
        public ExaminationDto OldExam
        {
            get { return oldExam; }
            set { oldExam = value; }
        }
        public ExaminationDto NewExam
        {
            get { return newExam;  }
            set { newExam = value; }
        }
    }
}
