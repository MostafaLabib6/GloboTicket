using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Category.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    public IMapper _mapper { get; }
    public ICategoryRepository _repository { get; }
    public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var CreationResponse = new CreateCategoryCommandResponse();

        var CategoryValidation = new CreateCategoryValidation();

        var validationResault = await CategoryValidation.ValidateAsync(request, cancellationToken);

        if (validationResault.Errors.Count > 0)
        {
            CreationResponse.Success = false;
            foreach (var error in validationResault.Errors)
                CreationResponse.ErrorList.Add(error.ErrorMessage);
        }
        else
        {
            CreationResponse.Success = true;
            var category = new Core.Domain.Entities.Category() { Name = request.Name };
            category = await _repository.Add(category);
        }


        return _mapper.Map<CreateCategoryCommandResponse>(CreationResponse);
    }
}
