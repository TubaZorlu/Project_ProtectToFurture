using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.Controllers
{
	[Area("WebSite")]
	public class SiteVolunteerRegisterController : Controller
	{
		private readonly IVolunteerService _volunteerService;
		private readonly IValidator<VolunteerCreateDto> _createValidator;

		public SiteVolunteerRegisterController(IVolunteerService volunteerService, IValidator<VolunteerCreateDto> createValidator)
		{
			_volunteerService = volunteerService;
			_createValidator = createValidator;
		}



		public IActionResult VolunteerCreate()
		{
			return View();
		}

		[HttpPost]
		public IActionResult VolunteerCreate(VolunteerCreateDto dto)
		{
			var validationResult = _createValidator.Validate(dto);
			if (validationResult.IsValid)
			{
				_volunteerService.Create(dto);
				return RedirectToAction("ThankYou");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(dto);
		}

		public IActionResult ThankYou()
		{
			return View();
		}


	}
}
