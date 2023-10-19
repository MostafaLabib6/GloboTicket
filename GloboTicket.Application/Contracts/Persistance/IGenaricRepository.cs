﻿

using System.Linq.Expressions;

namespace GloboTicket.Application.Contracts.Persistance;

public interface IGenaricRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAll();
    
    public Task<T> Get(Expression<Func<T,bool>> filter);
    public Task<T> Add(T entity);
    public Task Update(T entity); 

    public Task Delete(T entity);

}