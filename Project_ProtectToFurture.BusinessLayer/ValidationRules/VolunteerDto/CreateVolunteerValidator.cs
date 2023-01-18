using FluentValidation;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.VolunteerDto
{
    public class CreateVolunteerValidator:AbstractValidator<VolunteerCreateDto>
    {
        public CreateVolunteerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez").NotNull().WithMessage("İsim boş geçilemez").MaximumLength(20).WithMessage("İsim maksimum 20 karakter içermelidir").MinimumLength(2).WithMessage("İsim minumum 2 karakter içerebilir");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez").NotNull().WithMessage("Soyisim boş geçilemez").MaximumLength(20).WithMessage("Soyisim maksimum 20 karakter içermelidir").MinimumLength(2).WithMessage("Soyisim minumum 2 karakter içerebilir");
            RuleFor(x => x.VolunteerEmail).NotEmpty().WithMessage("Email boş geçilemez").NotNull().WithMessage("Email boş geçilemez");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında boş geçilemez").NotNull().WithMessage("Hakkında boş geçilemez").MinimumLength(100).WithMessage("Hakkında en az 100 karakter içermelidir.");
            RuleFor(x => x.VolunteerEmail).NotEmpty().WithMessage("Email boş geçilemez").NotNull().WithMessage("Email boş geçilemez");

        }
    }
}
