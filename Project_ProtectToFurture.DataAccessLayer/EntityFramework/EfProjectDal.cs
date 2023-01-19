using Microsoft.EntityFrameworkCore;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DataAccessLayer.Repository;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DataAccessLayer.EntityFramework
{
    public class EfProjectDal : GenericRepository<Project>, IProjectDal
    {
        public EfProjectDal(ProjectContext projectContext) : base(projectContext)
        {
        }

        public List<Project> GetProjectWithDonor()
        {
            using (var context = new ProjectContext())
            {
                var result = context.Projects.Include(x => x.Donor).ToList();
                return result;
            }
        }
    }
}
