using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.CQRS.Commands.AboutCommands
{
    public class CreateAboutCommand:IRequest
    {
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
       
    }
}
