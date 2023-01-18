using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
    public interface IFeatureService
    {
        List<FeatureListDto> GetAll();

        void Create(FeatureCreateDto dto);

        IDto GetById<IDto>(int id);

        void Delete(int id);

        void Update(FeatureUpdateDto dto);
    }
}
