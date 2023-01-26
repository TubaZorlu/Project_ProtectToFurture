using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DTOLayer.CQRS.Queries.AboutQueries;
using Project_ProtectToFurture.DTOLayer.CQRS.Results.AboutResult;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.UILayer.Areas.WebSite.ViewComponents
{
	public class _AboutPartial : ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			using (var context = new ProjectContext()) 
			{						
				var values = context.Abouts.OrderBy(x => x.AboutId).Take(1).FirstOrDefault();

				return View(values);
			}
			
		}
	}
}
