using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Queries;

public class GetEventListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventsListDto>>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _repository;
    public GetEventListQueryHandler(IMapper mapper, IEventRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<EventsListDto>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var events = await _repository.GetAll();
        return _mapper.Map<List<EventsListDto>>(events);
    }
}
