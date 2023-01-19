using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Context;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DonorController : Controller
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult DonorList()
        {          
            var values = _donorService.GetAll();         
            return View(values);
        }

    }
}
