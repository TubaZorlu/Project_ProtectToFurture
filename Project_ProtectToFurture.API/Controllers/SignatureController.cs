using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.API.Hubs;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignatureController : ControllerBase
	{
		private readonly SignatureService _signatureService;
		private readonly ProjectContext _projectContext;

		public SignatureController(SignatureService signatureService, ProjectContext projectContext)
		{
			_signatureService = signatureService;
			_projectContext = projectContext;
		}

		[HttpPost]
		public async Task<IActionResult> SaveCampaign(Signature signature)
		{
			await _signatureService.SaveData(signature);
		//	IQueryable<Signature> signatures = _signatureService.GetList
		//	
			return Ok(_signatureService.GetSignatureChart());
		}


		[HttpGet]
		public IActionResult SendDataToDatabase()
		{
			
			var count =_projectContext.Campaigns.Count();	
			Random rnd = new Random();

			if (count>0)
			{
                Enumerable.Range(0, 10).ToList().ForEach(x => {

                    for (int i = 1; i < count; i++)
                    {
                        var signature = new Signature
                        {
                            CampaignId = i,
                            SignatureCount = rnd.Next(10, 100),
                            SignatureDate = DateTime.Now.AddDays(i)
                        };

                        //işlemlerin hepsi bir saniye aralıkla gerçekleşicek
                        _signatureService.SaveData(signature).Wait();
                        System.Threading.Thread.Sleep(1000);
                    }
                });

            }
			else
			{
				return Ok("Sistemde kayıtlı kampanya bulunamadığından imza verileri oluşturulamadı");
			}

	

			

			return Ok("Kampanya imza verileri veri tabanına kaydedildi");
		}

	}

}
