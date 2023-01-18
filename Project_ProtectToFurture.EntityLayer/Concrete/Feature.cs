using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Feature
	{
		//projeler hakkında bloglar alanlarımız
		public int FeatureId { get; set; }
		public string Title { get; set; }
		public string Descriptin  { get; set; }
		public DateTime CreatedDate  { get; set; } =DateTime.Now;
		public bool Status { get; set; } = true;

	}
}
