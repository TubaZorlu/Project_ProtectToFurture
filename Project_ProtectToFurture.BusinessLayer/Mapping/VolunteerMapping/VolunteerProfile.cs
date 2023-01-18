using AutoMapper;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.VolunteerMapping
{
    public class VolunteerProfile:Profile
    {
        public VolunteerProfile()
        {
            CreateMap<Volunteer,VolunterListDto>().ReverseMap();
            CreateMap<Volunteer,VolunteerCreateDto>().ReverseMap();
            CreateMap<Volunteer,VolunteerUpdateDto>().ReverseMap();
        }
    }
}
