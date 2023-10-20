
using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using MediatR;

namespace GloboTicket.Application.Features.Event.Commands.Delete;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _repository;
    public DeleteEventCommandHandler(IMapper mapper, IEventRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(request.Id);
        if (entity == null)
            throw new ArgumentException();

        await _repository.Delete(entity);
        return Unit.Value;
    }
}
