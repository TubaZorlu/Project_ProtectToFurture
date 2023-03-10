using AutoMapper;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(FeatureCreateDto dto)
        {
            _unitOfWork.GetRepository<Feature>().Insert(_mapper.Map<Feature>(dto));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removeEntity = _unitOfWork.GetRepository<Feature>().GetById(id);
            _unitOfWork.GetRepository<Feature>().Delete(removeEntity);
            _unitOfWork.Save();
        }

        public List<FeatureListDto> GetAll()
        {
            return _mapper.Map<List<FeatureListDto>>(_unitOfWork.GetRepository<Feature>().GetAll());
        }

        public IDto GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(_unitOfWork.GetRepository<Feature>().GetById(id));
        }

        public void Update(FeatureUpdateDto dto)
        {
            var updateEntity = _unitOfWork.GetRepository<Feature>().GetById(dto.FeatureId);
            if (updateEntity != null)
            {
                _unitOfWork.GetRepository<Feature>().Update(_mapper.Map<Feature>(dto), updateEntity);
                _unitOfWork.Save();
            }
        }
    }
}
