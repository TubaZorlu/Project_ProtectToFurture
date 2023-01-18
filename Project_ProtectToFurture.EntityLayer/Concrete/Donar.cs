using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Donar
	{
		//bağışçı bilgilerrinin tutulduğu tablo
		public int DonarId { get; set; }
		public double Amout { get; set; }
		public string DonarName { get; set; }
		public string DonarSurname { get; set; }
		public string DonarAdress { get; set; }
		public string DonarCity { get; set; }
		public string DonarEmail { get; set; }
		public string DonarPhone { get; set; }
		public bool Status { get; set; } = true;


	}
}
