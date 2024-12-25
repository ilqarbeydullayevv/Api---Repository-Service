using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ApiCrud.Business.DTOs.Category
{
    public  class CreateCategoryDTO
    {
        public string Name { get; set; }
    }

    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    { 
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("duzgun ad daxil edin")
                .MaximumLength(20)
                .WithMessage("uzunluq maksimum 20 ola biler");

                

        
        
        
        }
    }
}
