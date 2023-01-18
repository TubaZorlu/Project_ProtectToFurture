using FluentValidation;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.ContactValitaionRules
{
    public class CreateContactValidator:AbstractValidator<ContactCreateDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez").NotNull().WithMessage("İsim boş geçilemez").MaximumLength(50).WithMessage("İsim en fazla 50 karakter içerebilir").MinimumLength(2).WithMessage("İsim en az 2 karakter içerebilir.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş geçilemez").NotNull().WithMessage("Mesaj boş geçilemez").MinimumLength(50).WithMessage("Mesaj en az 50 karakter içerebilir");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez").NotNull().WithMessage("Email boş geçilemez");
           
        }

    }
}
