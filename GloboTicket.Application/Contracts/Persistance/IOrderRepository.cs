
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.Application.Contracts.Persistance;

public interface IOrderRepository : IGenaricRepository<Order>
{
    Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size);
    Task<int> GetTotalCountOfOrdersForMonth(DateTime date);
}
