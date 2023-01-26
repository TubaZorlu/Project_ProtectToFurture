using Project_ProtectToFurture.DTOLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.CampaignDtos
{
    public class CampaignUpdateDto:IDto
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
       
    }
}
