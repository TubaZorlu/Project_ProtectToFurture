using FluentValidation;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.VolunteerDto
{
    public class UpdateVolunteerValidator:AbstractValidator<VolunteerUpdateDto>
    {
        public UpdateVolunteerValidator()
        {
          
           
            RuleFor(x => x.VolunteerEmail).NotEmpty().WithMessage("Email boş geçilemez").NotNull().WithMessage("Email boş geçilemez");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında boş geçilemez").NotNull().WithMessage("Hakkında boş geçilemez").MinimumLength(100).WithMessage("Hakkında en az 100 karakter içermelidir.");
            RuleFor(x => x.VolunteerPhone).NotEmpty().WithMessage("Telefon boş geçilemez").NotNull().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş geçilemez").NotNull().WithMessage("Şehir boş geçilemez");
        }
    }
}
