using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.CampaignDtos;
using Project_ProtectToFurture.DTOLayer.SignatureDtos;
using System.Collections.Generic;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.Controllers
{
	[Area("WebSite")]
	public class SignatureController : Controller
	{
		private readonly ISignatureService _signatureService;
		private readonly ICampaignService _campaignService;

		public SignatureController(ISignatureService signatureService, ICampaignService campaignService)
		{
			_signatureService = signatureService;
			_campaignService = campaignService;
		}



		public IActionResult CampaignDetails()
		{
			var values = _campaignService.GetAll();
			return View(values);
		}

		public IActionResult CampaignDetailsById(int id)
		{
			var values = _campaignService.GetById<CampaignListDto>(id);
			return View(values);
		}

		public IActionResult CreateSignature(int id)
		{
			var values = _signatureService.GetWithCampaignById<SignatureCreateDto>(id);
	/*		var values = _signatureService.GetById<SignatureCreateDto>(id)*/;
		
			return View(values);
		}

		[HttpPost]
		public IActionResult CreateSignature(SignatureCreateDto dto)
		{
			dto.SignatureCount = 50;
			_signatureService.Create(dto);
			return RedirectToAction("ThankYou");
		}

		public IActionResult ThankYou()
		{
			return View();
		}
	}
}
