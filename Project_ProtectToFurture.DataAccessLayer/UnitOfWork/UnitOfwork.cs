using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DataAccessLayer.UnitOfWork
{
    public class UnitOfwork:IUnitOfWork
    {
        private readonly ProjectContext _projectContext;

        public UnitOfwork(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public IGenericDal<T> GetRepository<T>() where T : class
		{
            return new GenericRepository<T>(_projectContext);
		}

		public void Save() 
        {
            _projectContext.SaveChanges();
        }

        public async Task SaveAsync() 
        {
            await _projectContext.SaveChangesAsync();
        }
    }
}
