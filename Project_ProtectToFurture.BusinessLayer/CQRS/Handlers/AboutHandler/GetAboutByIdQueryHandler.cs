using MediatR;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DTOLayer.CQRS.Queries.AboutQueries;
using Project_ProtectToFurture.DTOLayer.CQRS.Results.AboutResult;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project_ProtectToFurture.BusinessLayer.CQRS.Handlers.AboutHandler
{
	public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
	{
		private readonly ProjectContext _projectContext;

		public GetAboutByIdQueryHandler(ProjectContext projectContext)
		{
			_projectContext = projectContext;
		}

		public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _projectContext.Abouts.FindAsync(request.AboutId);

			return new GetAboutByIdQueryResult
			{
				AboutId=request.AboutId,
				Title = values.Title,
				Title2 = values.Title2,
				Description = values.Description
			

			};
		}

	}

}
