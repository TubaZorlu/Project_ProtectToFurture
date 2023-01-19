using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using Project_ProtectToFurture.DTOLayer.DonorDto;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
    public interface IDonorService
    {
        List<DonorListDto> GetAll();
   
        void Create(DonorCreateDto dto);

        IDto GetById<IDto>(int id);

        void Delete(int id);
        //void Update(BlogUpdateDto dto);


    }
}
