using FluentValidation;
using System.Data;

namespace GloboTicket.Application.Features.Event.Commands.Update;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(p => p.EventUpdateDto.Name)
                      .NotEmpty().WithMessage("{PropertyName} is required.")
                      .NotNull()
                      .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.EventUpdateDto.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);
    }
}
