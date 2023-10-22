
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Persistance.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<IReadOnlyList<Category>> CategoryWithEvents()
    {

        return await _dbContext.Categories.Include(e => e.Events).ToListAsync();

    }
}
