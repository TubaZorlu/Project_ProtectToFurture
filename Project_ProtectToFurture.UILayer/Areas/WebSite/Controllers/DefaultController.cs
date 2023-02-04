using Microsoft.AspNetCore.Mvc;
using System;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.Controllers
{
	[Area("WebSite")]

	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			

			return View();
		}
	}
}
