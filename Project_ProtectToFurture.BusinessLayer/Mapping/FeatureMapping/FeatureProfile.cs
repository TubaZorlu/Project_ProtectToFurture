using AutoMapper;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.FeatureMapping
{
    public class FeatureProfile:Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureCreateDto>().ReverseMap();
            CreateMap<Feature, FeatureUpdateDto>().ReverseMap();
            CreateMap<Feature, FeatureListDto>().ReverseMap();
        }
    }
}
