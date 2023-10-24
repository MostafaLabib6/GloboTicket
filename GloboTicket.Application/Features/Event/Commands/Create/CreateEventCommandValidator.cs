using FluentValidation;
using GloboTicket.Application.Contracts.Persistance;

namespace GloboTicket.Application.Features.Event.Commands.Create;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{

    public IEventRepository _repository { get; }

    public CreateEventCommandValidator(IEventRepository repository)
    {
        _repository = repository;

        RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);

        RuleFor(e => e)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);
    }

    public async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken cancellationToken)
    {
        return !(await _repository.EventNameAndDateUnique(e.Name, e.Date));
    }   
}
