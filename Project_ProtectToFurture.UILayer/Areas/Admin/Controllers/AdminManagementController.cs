using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.EntityLayer.CallenderEvent;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminManagementController : Controller
	{
	
		public IActionResult Index()
		{
			ProjectContext db = new ProjectContext();
			var eventList = db.Events.ToList();
			return new JsonResult(eventList);

		}

	
		public IActionResult Callender()
        { 
           return View();

        }

		[HttpPost]
		public IActionResult Ekle(Event events)
		{
			ProjectContext db = new ProjectContext();
			db.Events.Add(events);
			db.SaveChanges();
			var values = JsonConvert.SerializeObject(events);
			return Json(values);
		}


		public IActionResult Sil(int id)
		{
			ProjectContext db = new ProjectContext();
			var values = db.Events.Find(id);
			db.Events.Remove(values);
			db.SaveChanges();
			return Json(values);
		}

	


	}
}
