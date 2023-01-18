using FluentValidation;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.FeatureValidationRules
{
    public class CreateFeatureValidator:AbstractValidator<FeatureCreateDto>
    {
        public CreateFeatureValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez").NotNull().WithMessage("Başlık boş geçilemez").MaximumLength(100).WithMessage("Başlık maksimum 100 karakter içermelidir").MinimumLength(2).WithMessage("Başlık minumum 2 karakter içerebilir");
            RuleFor(x => x.Descriptin).NotEmpty().WithMessage("Açıklama boş geçilemez").NotNull().WithMessage("Açıklama boş geçilemez").MinimumLength(100).WithMessage("Açıklamam minimum 100 karakter içermelidir");
        }
    }
}
