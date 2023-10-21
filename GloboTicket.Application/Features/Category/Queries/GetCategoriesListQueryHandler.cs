using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Models;
using MediatR;
namespace GloboTicket.Application.Features.Category.Queries
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCatgoriesListQuery, List<GetCategoryDto>>
    {
        public IMapper _mapper { get; }
        public ICategoryRepository _repository { get; }
        public GetCategoriesListQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public async Task<List<GetCategoryDto>> Handle(GetCatgoriesListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Core.Domain.Entities.Category> enities;
            if (request.IncludeEvents)
                enities = await _repository.CategoryWithEvents();
            else
                enities = await _repository.GetAll();

            return _mapper.Map<List<GetCategoryDto>>(enities);
        }
    }
}
