using MediatR;

namespace GloboTicket.Application.Features.Event.Commands.Delete
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
