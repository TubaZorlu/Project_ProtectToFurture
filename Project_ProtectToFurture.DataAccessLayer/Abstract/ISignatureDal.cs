
using Project_ProtectToFurture.EntityLayer.Concrete;

namespace Project_ProtectToFurture.DataAccessLayer.Abstract
{
	public interface ISignatureDal:IGenericDal<Signature>
	{
		Signature GetWithCampaign(int id);
	}
}
