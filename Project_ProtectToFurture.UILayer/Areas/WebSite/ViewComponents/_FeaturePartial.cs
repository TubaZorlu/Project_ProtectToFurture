using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _FeaturePartial:ViewComponent
	{
		private readonly IFeatureService _featureService;

		public _FeaturePartial(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _featureService.GetAll();
			return View(values);
		}
	}
}
