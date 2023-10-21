using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Features.Category.Commands.Create
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidation()
        {
            RuleFor(e => e.Name).NotEmpty()
                .WithMessage("Category Name is Requiered")
                .NotNull()
                .MaximumLength(50).WithMessage("Category name must be less than 50");

        }
    }
}
