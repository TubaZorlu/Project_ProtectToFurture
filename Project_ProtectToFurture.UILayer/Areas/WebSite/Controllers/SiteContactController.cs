using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.ContactDtos;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.Controllers
{
	[Area("WebSite")]
	public class SiteContactController : Controller
	{
		private readonly IContactService _contactService;
		private readonly IValidator<ContactCreateDto> _createValidator;

		public SiteContactController(IContactService contactService, IValidator<ContactCreateDto> createValidator)
		{
			_contactService = contactService;
			_createValidator = createValidator;
		}

		

		[HttpPost]
		public IActionResult SendAMail(ContactCreateDto dto)
		{
			var validationResult= _createValidator.Validate(dto);
			if (validationResult.IsValid) 
			{
				_contactService.Create(dto);
				return RedirectToAction("Successful");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return RedirectToAction("Unsuccessful");
		}

		public IActionResult Successful()
		{
			return View();
		}


		public IActionResult Unsuccessful()
		{
			return View();
		}


	}
}
