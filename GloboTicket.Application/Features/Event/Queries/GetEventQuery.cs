
using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Queries;

public class GetEventQuery : IRequest<EventDto>
{
    public Guid Id { get; set; }
}
