using FluentValidation;
using Project_ProtectToFurture.DTOLayer.CampaignDtos;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.CampaignValidationRules
{
    public class UpdateCampaignValidator: AbstractValidator<CampaignUpdateDto>
    {
        public UpdateCampaignValidator()
        {
            RuleFor(x => x.CampaignName).NotEmpty().WithMessage("Kampanya adı boş geçilemez").MaximumLength(100).WithMessage("Kampanya adı maksimum 100 karakter içerebilir").MinimumLength(5).WithMessage("Kampanya adı minumum 5 karakter içerebilir");
            RuleFor(x => x.CampaignDescription).NotEmpty().WithMessage("Açıklama adı boş geçilemez").MinimumLength(50).WithMessage("Açıklama minumum  50 karakter içerebilir");
        }

    }
}
