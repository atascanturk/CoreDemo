using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad bilgisi boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad Soyad alanı minumum 2 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Yazar Ad Soyad alanı maksimum 50 karakter olmalıdır");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
        }
    }
}
