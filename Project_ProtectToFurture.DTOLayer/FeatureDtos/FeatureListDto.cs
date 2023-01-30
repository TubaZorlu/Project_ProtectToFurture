using Project_ProtectToFurture.DTOLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.FeatureDtos
{
    public class FeatureListDto:IDto
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Descriptin { get; set; }
        public DateTime CreatedDate { get; set; }

		public string ImagerUrl { get; set; }


	}
}
