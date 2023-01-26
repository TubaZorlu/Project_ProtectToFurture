using AutoMapper;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
    public class VolunteerManager : IVolunteerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VolunteerManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(VolunteerCreateDto dto)
        {
            _unitOfWork.GetRepository<Volunteer>().Insert(_mapper.Map<Volunteer>(dto));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removeEntity = _unitOfWork.GetRepository<Volunteer>().GetById(id);
            _unitOfWork.GetRepository<Volunteer>().Delete(removeEntity);
            _unitOfWork.Save();
        }

        public List<VolunterListDto> GetAll()
        {
            return _mapper.Map<List<VolunterListDto>>(_unitOfWork.GetRepository<Volunteer>().GetAll());
        }

        public IDto GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(_unitOfWork.GetRepository<Volunteer>().GetById(id));
        }

        public void Update(VolunteerUpdateDto dto)
        {
            var updateEntity = _unitOfWork.GetRepository<Volunteer>().GetById(dto.VolunteerId);
            _unitOfWork.GetRepository<Volunteer>().Update(_mapper.Map<Volunteer>(dto), updateEntity);
            _unitOfWork.Save();

        }


    }
}
