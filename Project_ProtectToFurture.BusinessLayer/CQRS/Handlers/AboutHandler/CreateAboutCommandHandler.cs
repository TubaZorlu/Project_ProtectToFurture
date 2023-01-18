using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.CQRS.Commands.AboutCommands;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace Project_ProtectToFurture.BusinessLayer.CQRS.Handlers.AboutHandler
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly ProjectContext _projectContext;
        private readonly IUnitOfWork _unitOfWork;



        public CreateAboutCommandHandler(ProjectContext projectContext, IUnitOfWork unitOfWork)
        {
            _projectContext = projectContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {


            _projectContext.Abouts.Add(new About
            {
                Title = request.Title,
                Title2 = request.Title2,
                Description = request.Description,

            });

            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
