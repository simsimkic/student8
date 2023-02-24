using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Dtos
{
    public class ExaminationDto
    {
        private int iD;
        private int patientID;
        private int doctorID;
        private int roomID;
        private DateTime date;

        public ExaminationDto(int iD, int doctorID, int patientID, int roomID, DateTime date)
        {
            ID = iD;
            this.patientID = patientID;
            this.doctorID = doctorID;
            this.roomID = roomID;
            this.date = date;
        }

        public ExaminationDto(int doctorID, int patientID, int roomID, DateTime date)
        {
            this.patientID = patientID;
            this.doctorID = doctorID;
            this.roomID = roomID;
            this.date = date;
        }

        public ExaminationDto(int roomID)
        {
            this.roomID = roomID;
        }

        public ExaminationDto(DateTime date)
        {
            this.date = date;
        }

        public ExaminationDto()
        {
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }
        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
