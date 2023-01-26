using AutoMapper;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.CampaignDtos;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CampaignManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(CampaignCreateDto dto)
        {
            _unitOfWork.GetRepository<Campaign>().Insert(_mapper.Map<Campaign>(dto));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removeEntity = _unitOfWork.GetRepository<Campaign>().GetById(id);
            _unitOfWork.GetRepository<Campaign>().Delete(removeEntity);
            _unitOfWork.Save();
        }

        public List<CampaignListDto> GetAll()
        {
            return _mapper.Map<List<CampaignListDto>>(_unitOfWork.GetRepository<Campaign>().GetAll());
        }

        public IDto GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(_unitOfWork.GetRepository<Campaign>().GetById(id));
        }

        public void Update(CampaignUpdateDto dto)
        {
            var updateEntity = _unitOfWork.GetRepository<Campaign>().GetById(dto.CampaignId);
            _unitOfWork.GetRepository<Campaign>().Update(_mapper.Map<Campaign>(dto), updateEntity);
            _unitOfWork.Save();
        }
    }
}
