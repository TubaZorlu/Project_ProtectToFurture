using Microsoft.EntityFrameworkCore;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DataAccessLayer.Repository;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System.Linq;

namespace Project_ProtectToFurture.DataAccessLayer.EntityFramework
{
	public class EfSignatureDal : GenericRepository<Signature>, ISignatureDal
	{
		public EfSignatureDal(ProjectContext projectContext) : base(projectContext)
		{
		}

		public Signature GetWithCampaign(int id)
		{
			using (var context = new ProjectContext()) 
			{
				var result = context.Signatures.Include(x=>x.Campaign).Where(x=>x.SignatureId==id).FirstOrDefault();
				return result;
			}
		}
	}
}
