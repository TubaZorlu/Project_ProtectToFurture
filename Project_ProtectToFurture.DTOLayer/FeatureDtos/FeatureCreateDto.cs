using Project_ProtectToFurture.DTOLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.FeatureDtos
{
    public class FeatureCreateDto:IDto
    {
        public string Title { get; set; }
        public string Descriptin { get; set; }
    }
}
