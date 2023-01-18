using FluentValidation;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.DonorValidationRules
{
    public class DonorValidator:AbstractValidator<Donor>
    {
        public DonorValidator()
        {
            RuleFor(x => x.DonorName).NotEmpty().WithMessage("İsim boş geçilemez").MaximumLength(50).WithMessage("İsim en fazla 50 karakter içerebilir").MinimumLength(2).WithMessage("İsim en fazla 2 karakter içerebilir");
            RuleFor(x => x.DonorSurname).NotEmpty().WithMessage("Soyisim boş geçilemez").MaximumLength(50).WithMessage("Soyisim en fazla 50 karakter içerebilir").MinimumLength(2).WithMessage("Soyisim en fazla 2 karakter içerebilir");
            RuleFor(x => x.DonorPhone).NotEmpty().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.Amout).NotEmpty().WithMessage("Bağış tutarı boş geçilemez");
            RuleFor(x => x.DonorEmail).NotEmpty().WithMessage("Email boş geçilemez");
           
        }
    }
}
