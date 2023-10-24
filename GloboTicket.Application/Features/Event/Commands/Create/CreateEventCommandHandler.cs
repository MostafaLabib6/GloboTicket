using AutoMapper;
using GloboTicket.Application.Contracts.Infrastructure;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Models;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.Application.Features.Event.Commands.Create;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _repository;
    private readonly IEmailService _emailService;
    public CreateEventCommandHandler(IMapper mapper, IEventRepository repository, IEmailService emailService)
    {
        _mapper = mapper;
        _repository = repository;
        _emailService = emailService;
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

        Email email = new Email() { To = "anythingnotimportant7665@gmail.com", Subject = "Event Creation alarm", Body = "Dear user;" };
        try
        {
            await _emailService.SendEmail(email);
        }
        catch
        {
            // log it in logging file 
        }
        return entity.EventId;

    }
}
