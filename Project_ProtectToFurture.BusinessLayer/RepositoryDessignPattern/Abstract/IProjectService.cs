using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
    public interface IProjectService
    {
        List<ProjectListDto> GetAll();
        List<ProjectListDto> GetProjectWithDonor();

        void Create(ProjectCreateDto dto);

        IDto GetById<IDto>(int id);

        void Delete(int id);

        void Update(ProjectUpdateDto dto);
    }
}
