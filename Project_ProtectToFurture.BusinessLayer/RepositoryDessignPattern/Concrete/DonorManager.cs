using AutoMapper;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using Project_ProtectToFurture.DTOLayer.DonorDto;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
    public class DonorManager : IDonorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDonorDal _donorDal;



        public DonorManager(IUnitOfWork unitOfWork, IMapper mapper, IDonorDal donorDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _donorDal = donorDal;
        }

        public void Create(DonorCreateDto dto)
        {
            _unitOfWork.GetRepository<Donor>().Insert(_mapper.Map<Donor>(dto));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removeEntity = _unitOfWork.GetRepository<Donor>().GetById(id);
            _unitOfWork.GetRepository<Donor>().Delete(removeEntity);
            _unitOfWork.Save();
        }

        public List<DonorListDto> GetAll()
        {
           
            return _mapper.Map<List<DonorListDto>>(_unitOfWork.GetRepository<Donor>().GetAll());
        }

        public IDto GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(_unitOfWork.GetRepository<Donor>().GetById(id));
        }

        
    }
}
