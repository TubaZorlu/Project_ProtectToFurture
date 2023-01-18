using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
    public interface IContactService
    {
        List<ContactListDto> GetAll();

        void Create(ContactCreateDto dto);

        IDto GetById<IDto>(int id);

        void Delete(int id);

        

    }
}
