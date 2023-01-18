using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class AppRole:IdentityRole<int>
	{
		public DateTime CreatedTime { get; set; }= DateTime.UtcNow;
		public DateTime ModifiedTime { get; set; }
	}
}
