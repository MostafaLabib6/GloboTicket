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
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersForMonthQuery, PagedOrdersForMonthVm>
    {
        public IMapper _mapper { get; }
        public IOrderRepository _orderRepository { get; }
        public GetOrdersListQueryHandler(IMapper mapper, IOrderRepository repository)
        {
            _mapper = mapper;
            _orderRepository = repository;
        }
        public async Task<PagedOrdersForMonthVm> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
            var orders = _mapper.Map<List<OrdersForMonthDto>>(list);

            var count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);
            return new PagedOrdersForMonthVm() { Count = count, OrdersForMonth = orders, Page = request.Page, Size = request.Size };

        }

    }
}
