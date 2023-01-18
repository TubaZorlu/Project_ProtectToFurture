using FluentValidation;
using Project_ProtectToFurture.DTOLayer.CQRS.Commands.AboutCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.AboutValidationRules
{
    public class UpdateAboutValidator:AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ana başlık boş geçilemez").NotNull().WithMessage("Ana başlık gereklidir");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Alt başlık boş geçilemez").NotNull().WithMessage("Alt Başlık gereklidir");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Max 50 karakter içerebilir");
            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Min. 10 karakter içerebilir");
            RuleFor(x => x.Title2).MaximumLength(50).WithMessage("Max 50 karakter içerebilir");
            RuleFor(x => x.Title2).MinimumLength(10).WithMessage("Min 10 karakter içerebilir");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Min 10 karakter içerebilir");
        }

    }

}
