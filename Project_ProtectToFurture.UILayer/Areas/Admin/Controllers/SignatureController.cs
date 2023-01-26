using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.DataAccessLayer.Context;
using System.Data;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class SignatureController : Controller
	{

		public IActionResult Index()
		{
			
			return View();
		}
	}
}
