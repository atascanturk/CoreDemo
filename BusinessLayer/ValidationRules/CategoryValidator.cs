using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı minumum 2 karakter olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez.");
        }
    }
}
