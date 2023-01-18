using Microsoft.AspNetCore.Http;
using Project_ProtectToFurture.DTOLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.BlogDtos
{
	public class BlogCreateDto:IDto
	{
        public int BlogId { get; set; }
        public string Title { get; set; }
		public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
		public bool Status { get; set; } = true;

	}
}
