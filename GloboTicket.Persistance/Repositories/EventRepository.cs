using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using System.Linq.Expressions;

namespace GloboTicket.Persistance.Repositories;

public class EventRepository : BaseRepository<EventEntity>, IEventRepository
{
    public EventRepository(GloboTicketDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> EventNameAndDateUnique(string name, DateTime date)
    {
        var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(date.Date));
        return Task.FromResult(matches);
    }
}
