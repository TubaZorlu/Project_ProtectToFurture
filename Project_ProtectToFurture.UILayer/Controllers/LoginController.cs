using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_ProtectToFurture.DTOLayer.UserDto;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.UILayer.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserLoginDto model)
		{
			var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.Remember, true);
			var user = await _userManager.FindByNameAsync(model.UserName);



			if (ModelState.IsValid && user.EmailConfirmed == true)
			{


				var roles = await _userManager.GetRolesAsync(user);


				if (roles.Contains("Admin"))
				{
					if (result.Succeeded)
					{

						return RedirectToAction("GetAll", "About", new { area = "Admin" });

					}

					ModelState.AddModelError("", "Kullanıcı adı veya şifreniz hatalı");

				}
				else
				{
					if (result.Succeeded)
					{

						return RedirectToAction("Index", "Default", new { area = "WebSite" });

					}
					ModelState.AddModelError("", "Kullanıcı adı veya şifreniz hatalı");

				}


			}



			ModelState.AddModelError("", "Kullanıcı adı veya şifreniz hatalı");
			return View(model);
		}

		public async Task<IActionResult> SignOutt()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}

	}
}
