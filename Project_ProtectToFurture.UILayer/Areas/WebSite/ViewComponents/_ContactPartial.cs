using Microsoft.AspNetCore.Mvc;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _ContactPartial:ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
			return View();
		}
	}
}
