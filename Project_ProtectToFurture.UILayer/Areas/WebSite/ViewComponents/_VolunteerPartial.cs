using Microsoft.AspNetCore.Mvc;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _VolunteerPartial:ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
			return View();
		}
	}
}
