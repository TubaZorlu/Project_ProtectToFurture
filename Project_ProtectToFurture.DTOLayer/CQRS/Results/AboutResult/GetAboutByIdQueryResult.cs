using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.CQRS.Results.AboutResult
{
	public class GetAboutByIdQueryResult
	{
        public int AboutId { get; set; }
        public string Title { get; set; }
		public string Title2 { get; set; }
		public string Description { get; set; }
		
	}
}
