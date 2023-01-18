using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand:IRequest
    {
        public RemoveAboutCommand(int aboutId)
        {
            AboutId = aboutId;
        }

        public int AboutId { get; set; }

    }
}
