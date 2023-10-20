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
        var entity = await _repository.Add(_mapper.Map<EventEntity>(request));
        return entity.EventId;

    }
}
