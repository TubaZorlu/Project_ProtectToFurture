using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.DonorDto;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.Controllers
{
	[Area("WebSite")]
	public class SiteDonorController : Controller
	{
		private readonly IDonorService _donorService;
		private readonly IValidator<DonorCreateDto> _createValidator;

		public SiteDonorController(IDonorService donorService, IValidator<DonorCreateDto> createValidator)
		{
			_donorService = donorService;
			_createValidator = createValidator;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult MakeADonation()
		{
			return View();
		}

		[HttpPost]
		public IActionResult MakeADonation(DonorCreateDto dto)
		{
			var validationResult = _createValidator.Validate(dto);
			if (validationResult.IsValid)
			{
				_donorService.Create(dto);
				return RedirectToAction("Payment");
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

		public IActionResult Payment()
		{
			return View();
		}

		

	}
}
