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
            var validator = new UpdateEventCommandValidator();

            // check for Event Existance 
            var eventToUpdate = await _repository.Get(x => x.Name == request.Name);
            if (eventToUpdate != null)
                throw new Exceptions.NotFoundException("The name of the Event not fount...");


            //validate Request input
            var ValidatorResult = await validator.ValidateAsync(request);
            if (ValidatorResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(ValidatorResult);


            _mapper.Map(request, eventToUpdate);
            return Unit.Value;

        }
    }
}
