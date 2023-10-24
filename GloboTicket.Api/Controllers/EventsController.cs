using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Features.Event.Commands.Create;
using GloboTicket.Application.Features.Event.Commands.Delete;
using GloboTicket.Application.Features.Event.Commands.Update;
using GloboTicket.Application.Features.Event.Queries;
using GloboTicket.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEventRepository _eventRepository;

        public EventsController(IMediator mediator, IEventRepository eventRepository)
        {
            _mediator = mediator;
            _eventRepository = eventRepository;
        }

        [HttpGet(Name = "GetEvents")]
        public async Task<ActionResult<List<EventsListDto>>> GetEvents()
        {
            var dtos = await _mediator.Send(new GetEventsListQuery());
            return dtos;
        }
        [HttpGet("{eventId}", Name = "GetEvent")]
        public async Task<ActionResult<EventDto>> GetEvent(Guid eventId)
        {
            var dto = await _mediator.Send(new GetEventQuery() { Id = eventId });
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }
        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create(CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return CreatedAtRoute("GetEvent", new { EventId = id }, id);
        }
        [HttpPut(Name = "UpdateEvent")]
        public async Task<ActionResult> updateEvent(UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteEvent")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventCommand() { Id = id });
            return NoContent();
        }
    }
}
