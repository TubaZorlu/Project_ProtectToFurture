using FluentValidation;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using System.Data;

namespace Project_ProtectToFurture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
      
		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
			
		}


        public IActionResult ContactList()
        {
            var values= _contactService.GetAll();
            return View(values);
        }

        public IActionResult GetById(int id)
        {
           var values= _contactService.GetById<ContactListDto>(id);
            return View(values);
        }

		public IActionResult ContactAdd()
		{
			return View();
		}

        [HttpPost]
		public IActionResult ContactAdd(ContactCreateDto dto)
		{
            dto.Name = "Admin";
            dto.Phone = "55555555555";                    

            if (ModelState.IsValid)
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddress = new MailboxAddress("Admin", "tubatastan24@gmail.com");
                mimeMessage.From.Add(mailboxAddress);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", dto.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = dto.Message;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "DogalYasamVakfı-Yönetim";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("tubatastan24@gmail.com", "lqdrvwahsdfuwxai");
                client.Send(mimeMessage);
                client.Disconnect(true);

                _contactService.Create(dto);
                return RedirectToAction("ContactList");
            }
            
			return View(dto);
		}

        public IActionResult ContactDelete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("ContactList");
        }
    }
}
