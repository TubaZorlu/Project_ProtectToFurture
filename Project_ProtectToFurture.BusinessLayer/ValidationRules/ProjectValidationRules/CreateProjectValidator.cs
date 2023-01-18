using FluentValidation;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.ProjectValidationRules
{
    public class CreateProjectValidator:AbstractValidator<ProjectCreateDto>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez").NotNull().WithMessage("Başlık boş geçilemez").MaximumLength(100).WithMessage("Başlık maksimum 100 karakter içermelidir").MinimumLength(2).WithMessage("Başlık minumum 2 karakter içerebilir");
            RuleFor(x => x.Area).NotEmpty().WithMessage("Başlık boş geçilemez").NotNull().WithMessage("Başlık boş geçilemez").MaximumLength(100).WithMessage("Başlık maksimum 100 karakter içermelidir").MinimumLength(2).WithMessage("Başlık minumum 2 karakter içerebilir");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Başlık boş geçilemez").NotNull().WithMessage("Başlık boş geçilemez").MaximumLength(100).WithMessage("Başlık maksimum 100 karakter içermelidir").MinimumLength(2).WithMessage("Başlık minumum 2 karakter içerebilir");
            RuleFor(x => x.FundNeed).NotEmpty().WithMessage("Tutar Boş geçilemez");
        }
    }
}

