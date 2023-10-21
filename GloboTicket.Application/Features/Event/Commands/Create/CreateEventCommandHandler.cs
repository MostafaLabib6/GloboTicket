using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.Application.Features.Event.Commands.Create;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _repository;
    public CreateEventCommandHandler(IMapper mapper, IEventRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateEventCommandValidator(_repository);
        var ValidationResult = await validator.ValidateAsync(request);

        // if user missing some data that neccessary for Creation of The event 
        // Fluent validation catch them and throw Validation error that contains all fields input errors.
        // otherwise the Creation of the user is ok.
        if (ValidationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(ValidationResult);

        var entity = await _repository.Add(_mapper.Map<EventEntity>(request));

        return entity.EventId;

    }
}
