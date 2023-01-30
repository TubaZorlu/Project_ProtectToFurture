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

		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
	
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


			if (ModelState.IsValid)
			{
				_blogService.Create(dto);
				return RedirectToAction("GetAll");
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

			if (ModelState.IsValid) 
			{
				_blogService.Update(dto);
				return RedirectToAction("GetAll");
			}
		

			return View(dto);
		}

		public IActionResult BlogDelete(int id)
		{
	
			_blogService.Delete(id);
			return RedirectToAction("GetAll");
		}

	}
}
