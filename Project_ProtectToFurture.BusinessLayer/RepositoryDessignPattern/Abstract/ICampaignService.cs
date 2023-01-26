using Project_ProtectToFurture.DTOLayer.CampaignDtos;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
    public interface ICampaignService
    {
        List<CampaignListDto> GetAll();

        void Create(CampaignCreateDto dto);

        IDto GetById<IDto>(int id);

        void Delete(int id);

        void Update(CampaignUpdateDto dto);

    }
}
