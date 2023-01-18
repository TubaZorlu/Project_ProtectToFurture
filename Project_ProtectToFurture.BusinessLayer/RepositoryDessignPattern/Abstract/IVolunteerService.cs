using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
    public interface IVolunteerService
    {
        List<VolunterListDto> GetAll();

        void Create(VolunteerCreateDto dto);

        IDto GetById<IDto>(int id);

        void Delete(int id);

        void Update(VolunteerUpdateDto dto);

    }
}
