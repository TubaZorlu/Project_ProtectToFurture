using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Feature
	{
		//çalşıma alanlarımız
		public int FeatureId { get; set; }
		public string Title { get; set; }
		public string Descriptin  { get; set; }
		public bool Status { get; set; } = true;

	}
}
