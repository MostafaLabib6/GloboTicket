using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Queries;

public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventDto>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _repository;
    public GetEventQueryHandler(IMapper mapper, IEventRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<EventDto> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(request.Id);
        return _mapper.Map<EventDto>(entity);
    }
}
