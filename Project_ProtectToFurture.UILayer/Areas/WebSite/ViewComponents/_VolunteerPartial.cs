using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	
	public class _VolunteerPartial:ViewComponent
	{
		private readonly IVolunteerService _volunteerService;

		public _VolunteerPartial(IVolunteerService volunteerService)
		{
			_volunteerService = volunteerService;
		}

		public IViewComponentResult Invoke() 
		{
			var values = _volunteerService.GetAll();
			return View(values);
		}
	}
}
