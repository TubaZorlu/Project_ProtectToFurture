using Project_ProtectToFurture.DTOLayer.Abstract;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.ProjectDtos
{
    public class ProjectListDto:IDto
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public double FundNeed { get; set; }
        public string Area { get; set; }
        public string Details { get; set; }
        public Donor Donor { get; set; }

    }
}
