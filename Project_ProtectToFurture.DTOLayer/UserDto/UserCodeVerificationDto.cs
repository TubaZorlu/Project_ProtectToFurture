using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.UserDto
{
	public class UserCodeVerificationDto
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Code { get; set; }
	}
}
