using Project_ProtectToFurture.DTOLayer.Abstract;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.SignatureDtos
{
	public class SignatureCreateDto:IDto
	{
		
		public int SignatureCount { get; set; }
		public Campaign Campaign { get; set; }
		public int CampaignId { get; set; }
		
	}
}
