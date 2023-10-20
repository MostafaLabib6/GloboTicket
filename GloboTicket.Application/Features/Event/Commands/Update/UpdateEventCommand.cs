using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Commands.Update;

public class UpdateEventCommand : IRequest
{
    public EventUpdateDto EventUpdateDto { get; set; } = new();
}
