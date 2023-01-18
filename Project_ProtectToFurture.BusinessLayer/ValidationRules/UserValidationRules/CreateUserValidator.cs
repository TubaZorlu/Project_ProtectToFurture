using FluentValidation;
using Project_ProtectToFurture.DTOLayer.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.UserValidationRules
{
	public class CreateUserValidator:AbstractValidator<UserCreateDto>
	{
		public CreateUserValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez").NotNull().WithMessage("İsim gereklidir").MinimumLength(2).WithMessage("Minumum 2 karakter içerebilir");
			RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez").NotNull().WithMessage("Soy İsim gereklidir").MinimumLength(2).WithMessage("Minumum 2 karakter içerebilir");
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez").NotNull().WithMessage("kullanıcı adı egereklidir").MaximumLength(10).WithMessage("Maksimum 10 karakter içerebilir").MinimumLength(3).WithMessage("Minumum 3 karakter içereebilir");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Mail boş geçilemez").NotNull().WithMessage("Mail gereklidir").MaximumLength(20).WithMessage("Maksimum 30 karakter içerebilir"); ;
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
			RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("Şifre Onayı boş geçilemez").Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor ");
			RuleFor(x => x.City).MinimumLength(3).WithMessage("Min. 3 karakter içerebilir").NotEmpty().WithMessage("Şehir boş geçilemez");
			
		}

	}
}
