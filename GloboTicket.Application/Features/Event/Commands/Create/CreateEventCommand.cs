using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Commands.Create;

public class CreateEventCommand : IRequest<Guid>
{
    public EventCreationDto EventCreationDto { get; set; } = new();
}
