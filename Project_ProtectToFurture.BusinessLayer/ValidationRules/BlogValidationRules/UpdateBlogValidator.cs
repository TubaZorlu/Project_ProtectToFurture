using FluentValidation;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.ValidationRules.BlogValidationRules
{
	public class UpdateBlogValidator:AbstractValidator<BlogUpdateDto>
	{
		public UpdateBlogValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez").NotNull().WithMessage("Başlık boş geçilemez").MaximumLength(20).WithMessage("Başlık maksimum 50 karakter içerebilir").MinimumLength(2).WithMessage("Başlık minimum 2 karakter içerebilir");
			RuleFor(x => x.Description).MinimumLength(50).WithMessage("Açıklama minimum 100 karakter içerebilir");
		}
	}
}
