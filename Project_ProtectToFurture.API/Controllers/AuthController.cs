using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_ProtectToFurture.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		[HttpPost]
		public IActionResult Login() 
		{
			return Created("", new TokenGenerator().GeneretaToken());
		}

	}
}
