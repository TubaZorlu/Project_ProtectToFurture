
using AutoMapper;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.BlogMapping
{
	public class BlogProfile:Profile
	{
		public BlogProfile()
		{
			CreateMap<Blog,BlogCreateDto>().ReverseMap();
			CreateMap<Blog,BlogListDto>().ReverseMap();
			CreateMap<Blog, BlogUpdateDto>().ReverseMap();
			CreateMap<BlogListDto,BlogUpdateDto>().ReverseMap();
		
		}
	}
}
