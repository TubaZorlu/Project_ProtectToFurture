using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.UserDto
{
	public class UserCreateDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string PasswordConfirm { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
	}
}
