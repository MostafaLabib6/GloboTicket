using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Persistance.Repositories
{
    public class BaseRepository<T> : IGenaricRepository<T> where T : class
    {
        public GloboTicketDbContext _dbContext { get; }
        public BaseRepository(GloboTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(filter) ?? default!;
        }

        public async Task<T> Get(Guid Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id) ?? default!;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

}
