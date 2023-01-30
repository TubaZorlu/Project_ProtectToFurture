using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using System.Data;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
     
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
            
        }

        public IActionResult FeatureList()
        {
            var result = _featureService.GetAll();
            return View(result);
        }

        public IActionResult GetById(int id)
        {
            var values = _featureService.GetById<FeatureListDto>(id);
            return View(values);
        }

        public IActionResult FeatureAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeatureAdd(FeatureCreateDto dto)
        {
            
            if (ModelState.IsValid)
            {
                _featureService.Create(dto);
                return RedirectToAction("FeatureList");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult FeatureUpdate(int id)
        {
            var result = _featureService.GetById<FeatureUpdateDto>(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult FeatureUpdate(FeatureUpdateDto dto)
        {     

            if (ModelState.IsValid)
            {
                _featureService.Update(dto);
                return RedirectToAction("FeatureList");
            }
           
			return View(dto);
		}

		public IActionResult FeatureDelete(int id)
		{

			_featureService.Delete(id);
			return RedirectToAction("FeatureList");
		}
	}
}
