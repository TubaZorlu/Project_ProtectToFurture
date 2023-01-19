using System.ComponentModel.DataAnnotations.Schema;

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

		public int DonorId { get; set; }
		public Donor Donor { get; set; }

	}
}
