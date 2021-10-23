using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class BlogValidator :AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog için bir başlık giriniz.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanını boş geçemezsiniz.");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Lütfen maksimum 150 karakter giriniz.");
        }
    }
}
