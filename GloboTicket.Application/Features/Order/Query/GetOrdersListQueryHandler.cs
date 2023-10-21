using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Features.Category.Queries;
using GloboTicket.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Features.Order.Query
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrderListQuery, List<GetCategoryDto>>
    {
        public IMapper _mapper { get; }
        public ICategoryRepository _repository { get; }
        public GetOrdersListQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<GetCategoryDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var entiry = await _repository.GetAll();

            return _mapper.Map<List<GetCategoryDto>>(entiry);
        }
    }
}
