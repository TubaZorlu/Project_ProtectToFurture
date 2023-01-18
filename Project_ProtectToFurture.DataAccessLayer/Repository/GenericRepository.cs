using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ProjectContext _projectContext;

        public GenericRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public void Delete(T t)
        {
            _projectContext.Remove(t);
        }

        public List<T> GetAll()
        {
            return _projectContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _projectContext.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            _projectContext.Add(t);
        }

		public void Update(T t, T unchanged)
		{
			_projectContext.Entry(unchanged).CurrentValues.SetValues(t);
		}
	}
}
