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
        private readonly IValidator<FeatureCreateDto> _createValidator;
        private readonly IValidator<FeatureUpdateDto> _updateValidator;

        public FeatureController(IFeatureService featureService, IValidator<FeatureCreateDto> createValidator, IValidator<FeatureUpdateDto> updateValidator)
        {
            _featureService = featureService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            return View();
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
            var validationResult = _createValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                _featureService.Create(dto);
                return RedirectToAction("FeatureList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
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

            var validationResult = _updateValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                _featureService.Update(dto);
                return RedirectToAction("FeatureList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(dto);
            }



        }

		public IActionResult FeatureDelete(int id)
		{

			_featureService.Delete(id);
			return RedirectToAction("FeatureList");
		}
	}
}
