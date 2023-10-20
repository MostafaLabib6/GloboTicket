

using GloboTicket.TicketManagement.Domain.Entities;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace GloboTicket.Application.Contracts.Persistance;

public interface IEventRepository:IGenaricRepository<EventEntity>
{

}
