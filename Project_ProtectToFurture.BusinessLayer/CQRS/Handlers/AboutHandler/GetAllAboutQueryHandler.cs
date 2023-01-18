using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DTOLayer.CQRS.Queries.AboutQueries;
using Project_ProtectToFurture.DTOLayer.CQRS.Results.AboutResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.CQRS.Handlers.AboutHandler
{
	public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutOuery, IEnumerable<GetAllAboutQueryResult>>
	{
		private readonly ProjectContext _projectContext;

		public GetAllAboutQueryHandler(ProjectContext projectContext)
		{
			_projectContext = projectContext;
		}

		public async Task<IEnumerable<GetAllAboutQueryResult>> Handle(GetAllAboutOuery request, CancellationToken cancellationToken)
		{
			return await _projectContext.Abouts.Select(x=> new GetAllAboutQueryResult
			{
				AboutId= x.AboutId,
				Title= x.Title,
				Title2= x.Title2,
				Description= x.Description
				
			}).AsNoTracking().ToListAsync();

		}
	}
}
