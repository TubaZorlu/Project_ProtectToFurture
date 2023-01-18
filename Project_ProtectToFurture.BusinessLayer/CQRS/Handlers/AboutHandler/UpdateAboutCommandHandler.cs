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
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly ProjectContext _projectContext;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAboutCommandHandler(ProjectContext projectContext, IUnitOfWork unitOfWork)
        {
            _projectContext = projectContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var updateAbout = _projectContext.Abouts.Find(request.AboutId);
            updateAbout.Title=request.Title;
            updateAbout.Title2=request.Title2;
            updateAbout.Description=request.Description;
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
