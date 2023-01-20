using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using System.Data;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class VolunteerController : Controller
	{
		private readonly IVolunteerService _volunteerService;
		private readonly IValidator<VolunteerUpdateDto> _updateValidator;

		public VolunteerController(IVolunteerService volunteerService, IValidator<VolunteerUpdateDto> updateValidator)
		{
			_volunteerService = volunteerService;
			_updateValidator = updateValidator;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult VolunteerList()
		{
			var values = _volunteerService.GetAll();
			return View(values);
		}

		public IActionResult GetById(int id)
		{
			var value = _volunteerService.GetById<VolunterListDto>(id);
			return View(value);
		}


		public IActionResult VolunteerDelete(int id)
		{
			var value = _volunteerService.GetById<VolunteerUpdateDto>(id);
			if (value.Status==true)
			{
				value.Status = false;
			}
			else
			{
				value.Status=true;
			}
			_volunteerService.Update(value);
			return RedirectToAction("VolunteerList");
		}

		public IActionResult VolunteerUpdate(int id)
		{
			var result = _volunteerService.GetById<VolunteerUpdateDto>(id);
			return View(result);
		}
		[HttpPost]
		public IActionResult VolunteerUpdate(VolunteerUpdateDto dto)
		{
			var validationResult = _updateValidator.Validate(dto);

			if (validationResult.IsValid)
			{
				_volunteerService.Update(dto);
				return RedirectToAction("VolunteerList");
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


	}
}
