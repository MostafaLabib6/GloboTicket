

using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Queries;

public class GetEventsListQuery :IRequest<List<EventsListDto>>
{
}
