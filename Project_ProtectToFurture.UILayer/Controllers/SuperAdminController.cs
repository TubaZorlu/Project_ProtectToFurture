using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System.Linq;

namespace Project_ProtectToFurture.UILayer.Controllers
{
	public class SuperAdminController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ProjectContext _context;

        public SuperAdminController(UserManager<AppUser> userManager, ProjectContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult KullaniciListesi()
		{
			var values = _userManager.Users;
			_context.Users.Join(_context.UserRoles, user => user.Id, userRole => userRole.UserId, (user, userRole) => new  {
			
			
				user,
				userRole
			}).Select(x=>new AppUser {
			
				Id=x.user.Id,
				Email=x.user.Email,
				Name=x.user.Name,
				Surname=x.user.Surname,
				
				
			}).ToList();

			var values2 = _userManager.GetUsersInRoleAsync("Volunteer");

			return View(values);
		}



	}
}
