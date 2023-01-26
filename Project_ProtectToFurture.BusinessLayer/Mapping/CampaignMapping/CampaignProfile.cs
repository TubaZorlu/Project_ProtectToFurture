using AutoMapper;
using Project_ProtectToFurture.DTOLayer.CampaignDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.CampaignMapping
{
    public class CampaignProfile:Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign,CampaignCreateDto>().ReverseMap();
            CreateMap<Campaign,CampaignListDto>().ReverseMap();
            CreateMap<Campaign,CampaignUpdateDto>().ReverseMap();
            
        }
    }
}
