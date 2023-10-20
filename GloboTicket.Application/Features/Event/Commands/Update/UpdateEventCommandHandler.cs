using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using MediatR;
namespace GloboTicket.Application.Features.Event.Commands.Update
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _repository;
        public UpdateEventCommandHandler(IMapper mapper, IEventRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _repository.Get(x => x.Name == request.EventUpdateDto.Name);
            if (eventToUpdate != null)
                throw new InvalidOperationException();
            _mapper.Map(request, eventToUpdate);
            return Unit.Value;

        }
    }
}
