using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using MediatR;

namespace GloboTicket.Application.Features.Category.Commands.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _repository;
    public DeleteCategoryCommandHandler(IMapper mapper, IEventRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(request.CategoryId);
        if (entity == null)
            throw new Exceptions.NotFoundException("Not Found Category..");
        await _repository.Delete(entity);
        return Unit.Value;
    }
}
