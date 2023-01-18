using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Project
	{
		//bağış yapılabilecek projeler
		public int ProjectId { get; set; }
		public string Title { get; set; }
		public double FundNeed { get; set; }
		public string Area { get; set; }
		public string Details { get; set; }
		public bool Status { get; set; } = true;

        public List<DonorProject> DonorProjects { get; set; }

    }
}
