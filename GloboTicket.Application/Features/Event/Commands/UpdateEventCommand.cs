
using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Commands;

public class UpdateEventCommand : IRequest
{
    public EventUpdateDto EventUpdateDto { get; set; } = new();
}
