using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class Blog
	{
		//çalışmalarımızı anlatan yazılar 
		public int BlogId { get; set; }
		public string Title { get; set; }		
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }=DateTime.Now;
		public bool Status { get; set; }=true;
	}
}
