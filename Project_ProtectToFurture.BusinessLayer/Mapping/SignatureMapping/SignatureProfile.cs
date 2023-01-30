using AutoMapper;
using Project_ProtectToFurture.DTOLayer.SignatureDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.SignatureMapping
{
	public class SignatureProfile:Profile
	{
		public SignatureProfile()
		{
			CreateMap<Signature,SignatureCreateDto>().ReverseMap();
		}
	}
}
