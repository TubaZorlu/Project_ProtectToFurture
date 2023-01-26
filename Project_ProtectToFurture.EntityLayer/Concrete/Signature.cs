using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Signature
	{
		public int SignatureId { get; set; }	
		public int SignatureCount { get; set; }
		public DateTime SignatureDate { get; set; } = DateTime.Now;
		public int CampaignId { get; set; }
		public Campaign Campaign { get; set; }


	}
}
