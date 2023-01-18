using AutoMapper;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.Mapping.ContactMapping
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact,ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactListDto>().ReverseMap();
        }
    }
}
