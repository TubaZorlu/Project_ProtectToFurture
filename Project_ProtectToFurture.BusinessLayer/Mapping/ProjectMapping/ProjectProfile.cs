using AutoMapper;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.ProjectMapping
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project,ProjectCreateDto>().ReverseMap();
            CreateMap<Project,ProjectListDto>().ReverseMap();
            CreateMap<Project,ProjectUpdateDto>().ReverseMap();
        }
    }
}
