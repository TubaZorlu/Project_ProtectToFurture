using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.CQRS.Handlers.AboutHandler;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.AboutValidationRules;
using Project_ProtectToFurture.DTOLayer.CQRS.Commands.AboutCommands;
using Project_ProtectToFurture.DTOLayer.CQRS.Queries.AboutQueries;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetAllAboutOuery());
            return View(values);

        }

        public async Task<IActionResult> GetAboutById(int id)
        {
            var result = await _mediator.Send(new GetAboutByIdQuery(id));
            return View(result);

        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutCommand command)
        {
            
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction("GetAll");
            }
         
            return View();


        }


        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = await _mediator.Send(new GetAboutByIdQuery(id));
            return View(values);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
           

            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction("GetAll");
            }
            
            return View();


        }


    
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return RedirectToAction("GetAll");

        }

    }
}
