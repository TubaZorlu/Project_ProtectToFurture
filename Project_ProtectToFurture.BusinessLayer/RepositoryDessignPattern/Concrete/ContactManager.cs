using AutoMapper;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System.Collections.Generic;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(ContactCreateDto dto)
        {
		

			_unitOfWork.GetRepository<Contact>().Insert(_mapper.Map<Contact>(dto));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removeEntity = _unitOfWork.GetRepository<Contact>().GetById(id);
            _unitOfWork.GetRepository<Contact>().Delete(removeEntity);
            _unitOfWork.Save();
        }

        public List<ContactListDto> GetAll()
        {
            return _mapper.Map<List<ContactListDto>>(_unitOfWork.GetRepository<Contact>().GetAll());  
        }

        public IDto GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(_unitOfWork.GetRepository<Contact>().GetById(id));
        }
    }
}
