using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
    public class DonorProject
    {
        //composite key ile tekrarlanan veri önüne geçtik
        public int DonorId { get; set; }
        public Donor Donor { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
