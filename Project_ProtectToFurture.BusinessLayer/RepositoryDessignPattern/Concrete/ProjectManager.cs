using AutoMapper;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(ProjectCreateDto dto)
        {
            _unitOfWork.GetRepository<Project>().Insert(_mapper.Map<Project>(dto));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removeEntity= _unitOfWork.GetRepository<Project>().GetById(id);
            _unitOfWork.GetRepository<Project>().Delete(removeEntity);
            _unitOfWork.Save();
        }

        public List<ProjectListDto> GetAll()
        {
            return _mapper.Map<List<ProjectListDto>>(_unitOfWork.GetRepository<Project>().GetAll());
        }

        public IDto GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(_unitOfWork.GetRepository<Project>().GetById(id));
        }

        public void Update(ProjectUpdateDto dto)
        {
            var updateEntity = _unitOfWork.GetRepository<Project>().GetById(dto.ProjectId);
            if (updateEntity !=null)
            {
                _unitOfWork.GetRepository<Project>().Update(_mapper.Map<Project>(dto), updateEntity);
                _unitOfWork.Save();
            }
        }
    }
}
