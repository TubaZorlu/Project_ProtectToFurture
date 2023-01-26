using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Campaign
	{
		public int CampaignId { get; set; }
		public string CampaignName { get; set;}
		public string CampaignDescription { get; set;}
		public bool Status { get; set;}=true;
		public List<Signature> Signatures { get;}
	}
}
