using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _ProjectPartial:ViewComponent
	{
		private readonly IProjectService _projectService;

		public _ProjectPartial(IProjectService projectService)
		{
			_projectService = projectService;
		}

		public IViewComponentResult Invoke() 
		{
			var values = _projectService.GetAll().Take(3).ToList();
			return View(values);
		}
	}
}
