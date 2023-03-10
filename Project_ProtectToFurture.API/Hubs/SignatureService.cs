using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project_ProtectToFurture.API.Model;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.API.Hubs
{
	public class SignatureService
	{
		private readonly ProjectContext _projectContext;
		private readonly IHubContext<SignatureHub> _hubContext;

		public SignatureService(ProjectContext projectContext, IHubContext<SignatureHub> hubContext)
		{
			_projectContext = projectContext;
			_hubContext = hubContext;
		}

		public IQueryable<Signature> GetList()
		{
			return _projectContext.Signatures.AsQueryable();
		}

		public async Task SaveData(Signature signature)
		{
			await _projectContext.Signatures.AddAsync(signature);
			await _projectContext.SaveChangesAsync();
			await _hubContext.Clients.All.SendAsync("ReceiveList", GetSignatureChart());
		}

		public List<SignatureChart> GetSignatureChart()
		{
			List<SignatureChart> signatureList = new List<SignatureChart>();
					

			var campaignList = from detay in _projectContext.Signatures
					group detay by detay.Campaign.CampaignName into Grup
					select new
					{
						Kampanya = Grup.Key,
						Imza = Grup.Sum(x => x.SignatureCount)
					};

			foreach (var item in campaignList)
			{
				SignatureChart sc = new SignatureChart
				{
					Name = item.Kampanya,
					Counts = item.Imza

				};


				signatureList.Add(sc);
			}
	

			return signatureList;
		}



	}
}

