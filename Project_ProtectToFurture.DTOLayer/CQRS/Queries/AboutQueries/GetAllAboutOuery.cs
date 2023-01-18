using MediatR;
using Project_ProtectToFurture.DTOLayer.CQRS.Results.AboutResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DTOLayer.CQRS.Queries.AboutQueries
{
	public class GetAllAboutOuery:IRequest<IEnumerable<GetAllAboutQueryResult>>
	{
	}
}
