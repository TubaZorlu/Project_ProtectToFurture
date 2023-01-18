using MediatR;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.CQRS.Commands.AboutCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.CQRS.Handlers.AboutHandler
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
    {
        private readonly ProjectContext _projectContext;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAboutCommandHandler(ProjectContext projectContext, IUnitOfWork unitOfWork)
        {
            _projectContext = projectContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var aboutValue = _projectContext.Abouts.Find(request.AboutId);
            _projectContext.Abouts.Remove(aboutValue);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
