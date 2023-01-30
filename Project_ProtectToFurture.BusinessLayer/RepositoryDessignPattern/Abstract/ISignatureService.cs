using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.DTOLayer.SignatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract
{
	public interface ISignatureService
	{
		void Create(SignatureCreateDto dto);

		IDto GetById<IDto>(int id);
		IDto GetWithCampaignById<IDto>(int id);
	}
}
