using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.DataAccessLayer.Context;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _AboutPartial2:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			using (var context = new ProjectContext())
			{
				var values = context.Abouts.OrderByDescending(x => x.AboutId).Take(1).FirstOrDefault();

				return View(values);
			}

		}
	}
}
