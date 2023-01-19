using Project_ProtectToFurture.DTOLayer.Abstract;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.DonorDto
{
    public class DonorCreateDto:IDto
    {

        public double Amout { get; set; }
        public string DonorName { get; set; }
        public string DonorSurname { get; set; }
        public string DonorCity { get; set; }
        public string DonorEmail { get; set; }
        public List<Project> Projects { get; set; }

    }
}
