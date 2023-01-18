using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Donor
	{
		//bağışçı bilgilerrinin tutulduğu tablo
		public int DonorId { get; set; }
		public double Amout { get; set; }
		public string DonorName { get; set; }
		public string DonorSurname { get; set; }
		public string DonorAdress { get; set; }
		public string DonorCity { get; set; }
		public string DonorEmail { get; set; }
		public string DonorPhone { get; set; }
		public bool Status { get; set; } = true;

		public List<DonorProject> DonorProjects { get;set; }

	}
}
