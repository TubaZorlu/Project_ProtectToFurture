using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using System.Data;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IValidator<ProjectCreateDto> _createValidator;
        private readonly IValidator<ProjectUpdateDto> _updateValidator;

        public ProjectController(IProjectService projectService, IValidator<ProjectCreateDto> createValidator, IValidator<ProjectUpdateDto> updateValidator)
        {
            _projectService = projectService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProjectList()
        {
            var result = _projectService.GetAll();
            return View(result);
        }

        public IActionResult ProjectListWithDonor()
        {
            var result = _projectService.GetProjectWithDonor();
            return View(result);
        }


        public IActionResult GetById(int id)
        {
            var result = _projectService.GetById<ProjectListDto>(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult ProjectAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ProjectAdd(ProjectCreateDto dto)
        {
            var validationResult = _createValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                _projectService.Create(dto);
                return RedirectToAction("ProjectList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(dto);
        }


        [HttpGet]
        public IActionResult ProjectUpdate(int id)
        {
            var result = _projectService.GetById<ProjectUpdateDto>(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult ProjectUpdate(ProjectUpdateDto dto)
        {
            var validationResult = _updateValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                _projectService.Update(dto);
                return RedirectToAction("ProjectList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View(dto);
        }



        public IActionResult ProjectDelete(int id)
        {
            _projectService.Delete(id);
            return RedirectToAction("ProjectList");
        }
    }
}
