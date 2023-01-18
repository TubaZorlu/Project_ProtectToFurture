using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.CallenderEvent
{
	public class Event
	{

		public int id { get; set; }

		public string title { get; set; }
		public string description { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public string color { get; set; }
		public string textColor { get; set; }
		public bool IsFullDay { get; set; }

	}
}
