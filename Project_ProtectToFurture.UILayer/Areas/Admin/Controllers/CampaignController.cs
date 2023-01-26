using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.CampaignDtos;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using System.Data;
using System.Net.NetworkInformation;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class CampaignController : Controller
	{
		private readonly ICampaignService _campaignService;
		private readonly IValidator<CampaignCreateDto> _createValidator;
		private readonly IValidator<CampaignUpdateDto> _updateValidator;

		public CampaignController(ICampaignService campaignService, IValidator<CampaignUpdateDto> updateValidator, IValidator<CampaignCreateDto> createValidator)
		{
			_campaignService = campaignService;
			_updateValidator = updateValidator;
			_createValidator = createValidator;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CampaignList()
		{
			var result = _campaignService.GetAll();
			return View(result);
		}

		public IActionResult GetById(int id)
		{
			var values = _campaignService.GetById<CampaignListDto>(id);
			return View(values);
		}

		public IActionResult CampaignAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CampaignAdd(CampaignCreateDto dto)
		{
			var validationResult = _createValidator.Validate(dto);
			if (validationResult.IsValid)
			{
				_campaignService.Create(dto);
				return RedirectToAction("CampaignList");
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
		public IActionResult CampaignUpdate(int id)
		{
			var result = _campaignService.GetById<CampaignUpdateDto>(id);
			return View(result);
		}


		[HttpPost]
		public IActionResult CampaignUpdate(CampaignUpdateDto dto)
		{

			var validationResult = _updateValidator.Validate(dto);

			if (validationResult.IsValid)
			{
				_campaignService.Update(dto);
				return RedirectToAction("CampaignList");
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

		public IActionResult CampaignDelete(int id)
		{

			_campaignService.Delete(id);
			return RedirectToAction("CampaignList");
		}


	}
}
