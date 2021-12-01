using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adını boş geçemezsiniz!")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalı!")
                .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalı!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz!");
            

        }
    }
}
