using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
    public class EfDonorDal : GenericRepository<Donor>, IDonorDal
    {
        public EfDonorDal(ProjectContext projectContext) : base(projectContext)
        {
        }

      

    }
}
