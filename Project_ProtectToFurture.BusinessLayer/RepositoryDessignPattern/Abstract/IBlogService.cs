using Project_ProtectToFurture.DTOLayer.Abstract;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
    public interface IBlogService
    {
        List<BlogListDto> GetAll();

        void Create(BlogCreateDto dto);

        IDto GetById<IDto>(int id);

        void Delete(int id);

        void Update(BlogUpdateDto dto);


    }
}
