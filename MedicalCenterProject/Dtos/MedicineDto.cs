using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterProject.Dtos
{
    public class MedicineDto
    {
        private int Id;
        private string Name;
        private int Quantity;
        private string Type;
        private bool Approved = false;

        public MedicineDto(int Id, string Name, int Quantity, string Type)
        {
            this.Id = Id;
            this.Name = Name;
            this.Quantity = Quantity;
            this.Type = Type;
        }
        public MedicineDto() { }

        public int Id1 { get => Id; set => Id = value; }
        public string Name1 { get => Name; set => Name = value; }
        public int Quantity1 { get => Quantity; set => Quantity = value; }
        public string Type1 { get => Type; set => Type = value; }
        public bool Approved1 { get => Approved; set => Approved = value; }
    }
}
