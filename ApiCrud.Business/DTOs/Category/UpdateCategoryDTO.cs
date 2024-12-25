using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ApiCrud.Business.DTOs.Category
{
   public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {

        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
