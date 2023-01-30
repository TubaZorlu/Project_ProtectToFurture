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
       
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
           
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
            if (ModelState.IsValid)
            {
                _projectService.Create(dto);
                return RedirectToAction("ProjectList");
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
           
            if (ModelState.IsValid)
            {
                _projectService.Update(dto);
                return RedirectToAction("ProjectList");
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
