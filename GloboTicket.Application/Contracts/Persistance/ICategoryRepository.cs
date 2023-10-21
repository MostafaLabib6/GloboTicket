using GloboTicket.Core.Domain.Entities;

namespace GloboTicket.Application.Contracts.Persistance;

public interface ICategoryRepository : IGenaricRepository<Category>
{
    public Task<IReadOnlyList<Category>> CategoryWithEvents();
}
