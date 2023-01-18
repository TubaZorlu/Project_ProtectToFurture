using Project_ProtectToFurture.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();

        IGenericDal<T> GetRepository<T>() where T : class;

    }
}
