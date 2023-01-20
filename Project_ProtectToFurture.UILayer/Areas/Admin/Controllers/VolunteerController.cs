using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using System.Data;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class VolunteerController : Controller
	{
		private readonly IVolunteerService _volunteerService;

		public VolunteerController(IVolunteerService volunteerService)
		{
			_volunteerService = volunteerService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult VolunteerList()
		{
			var values = _volunteerService.GetAll();
			return View(values);
		}

	}
}
