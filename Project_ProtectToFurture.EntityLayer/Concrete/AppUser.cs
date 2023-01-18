using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
	public class AppUser:IdentityUser<int>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Gender { get; set; }
		public string City { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public string Code { get; set; }
		public List<Volunteer> Volunteers { get; set; }
	}
}
