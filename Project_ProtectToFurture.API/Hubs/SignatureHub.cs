using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.API.Hubs
{
	public class SignatureHub : Hub
	{
		private readonly SignatureService _signatureService;

		public SignatureHub(SignatureService signatureService)
		{
			_signatureService = signatureService;
		}

		public async Task GetSignatureList()
		{
			await Clients.All.SendAsync("ReceiveList", _signatureService.GetSignatureChart());
		}
	}
}
