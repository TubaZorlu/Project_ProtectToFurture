using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.UserValidationRules;
using Project_ProtectToFurture.DTOLayer.UserDto;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;

namespace Project_ProtectToFurture.UILayer.Controllers
{

	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View(new UserCreateDto());
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserCreateDto model)
		{
			var validator = new CreateUserValidator();
			ValidationResult result = validator.Validate(model);

			if (result.IsValid)
			{
				Random rnd = new Random();
				int number = rnd.Next(100000, 999999);

				AppUser user = new()
				{
					Name = model.Name,
					Surname = model.Surname,
					UserName = model.UserName,
					Email = model.Email,
					PhoneNumber = model.Phone,
					Code = number.ToString(),
				};

				if (model.Password == model.PasswordConfirm)
				{
					var identityResult = await _userManager.CreateAsync(user, model.Password);

					if (identityResult.Succeeded)
					{
						SendMail(user);
						return RedirectToAction("EmailConfirmed", "Register");
					}

					foreach (var error in identityResult.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
				else
				{
					ModelState.AddModelError("", "şifreler uyuşmuyor");
				}
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(model);
		}


		[HttpGet]
		public IActionResult EmailConfirmed()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> EmailConfirmed(UserCodeVerificationDto model)
		{
			var user = await _userManager.FindByNameAsync(model.UserName);

			if (ModelState.IsValid && user!=null)
			{				
				if (model.Code == user.Code)
				{
					user.EmailConfirmed = true;
					await _userManager.UpdateAsync(user);
					return RedirectToAction("Index", "Login");

				}

				ModelState.AddModelError("", "Girilen kod hatalıdır");
				return View(model);

			}
			ModelState.AddModelError("", "Girilen bilgiler hatalıdır.Lütfen bilgilerinizi kontrol ediniz");

			return View(model);
		}

		public void SendMail(AppUser user)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddress = new MailboxAddress("Admin", "tubatastan24@gmail.com");
			mimeMessage.From.Add(mailboxAddress);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			var message = "Üyelik işlemlerini tamamlayabilmek için lütfen doğrulama kodununuzu onaylayınız. Doğrulama kodunuz :";
			bodyBuilder.TextBody = message.ToString() + " " + user.Code;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = "Üyelik Kayıt Onayı";

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("tubatastan24@gmail.com", "lqdrvwahsdfuwxai");
			client.Send(mimeMessage);
			client.Disconnect(true);

		}

	}
}
