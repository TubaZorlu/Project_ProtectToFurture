using AutoMapper;
using Project_ProtectToFurture.DTOLayer.DonorDto;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.DonorMapping
{
    public class DonorProfile:Profile
    {
        public DonorProfile()
        {
            CreateMap<Donor,DonorListDto>().ReverseMap();
            CreateMap<Donor,DonorCreateDto>().ReverseMap();
        }
    }
}
