using Microsoft.AspNetCore.Mvc;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _ProjectPartial:ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
			return View();
		}
	}
}
