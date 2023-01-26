using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _BlogPartial2:ViewComponent
	{
		private readonly IBlogService _blogService;

		public _BlogPartial2(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _blogService.GetAll().OrderBy(x => x.BlogId).Take(3).ToList();
			return View(values);
		}
	}
}
