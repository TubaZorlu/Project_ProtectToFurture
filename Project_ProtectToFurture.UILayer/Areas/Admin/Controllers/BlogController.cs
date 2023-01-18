using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using System;
using System.Data;
using System.IO;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IValidator<BlogCreateDto> _createValidator;
		private readonly IValidator<BlogUpdateDto> _updateValidator;

		public BlogController(IBlogService blogService, IValidator<BlogCreateDto> createValidator, IValidator<BlogUpdateDto> updateValidator)
		{
			_blogService = blogService;
			_createValidator = createValidator;
			_updateValidator = updateValidator;
		}

		public IActionResult Index()
		{
			return View();
		}


		public IActionResult GetAll()
		{
			var result = _blogService.GetAll();
			return View(result);
		}

		public IActionResult GetById(int id)
		{
			var result = _blogService.GetById<BlogListDto>(id);
			return View(result);
		}


		[HttpGet]
		public IActionResult BlogAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult BlogAdd(BlogCreateDto dto)
		{

			var validationResult = _createValidator.Validate(dto);

			if (validationResult.IsValid)
			{
				_blogService.Create(dto);
				return RedirectToAction("GetAll");
			}
			foreach (var item in validationResult.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}
			return View(dto);
		}



		[HttpGet]
		public IActionResult BlogUpdate(int id)
		{
			var result  = _blogService.GetById<BlogUpdateDto>(id);
			return View(result);
		}

		[HttpPost]
		public IActionResult BlogUpdate(BlogUpdateDto dto )
		{ 

			var validationResult = _updateValidator.Validate(dto);

			if (validationResult.IsValid) 
			{
				_blogService.Update(dto);
				return RedirectToAction("GetAll");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(dto);
			}
		}

		public IActionResult BlogDelete(int id)
		{
	
			_blogService.Delete(id);
			return RedirectToAction("GetAll");
		}

	}
}
