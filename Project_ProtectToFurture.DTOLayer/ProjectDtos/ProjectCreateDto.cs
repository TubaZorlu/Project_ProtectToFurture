using Project_ProtectToFurture.DTOLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.ProjectDtos
{
    public class ProjectCreateDto:IDto
    {
        public string Title { get; set; }
        public double FundNeed { get; set; }
        public string Area { get; set; }
        public string Details { get; set; }
    }
}
