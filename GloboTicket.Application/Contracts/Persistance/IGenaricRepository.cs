

namespace GloboTicket.Application.Contracts.Persistance;

public interface IGenaricRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAll();
    
    public Task<T> Get(int id);
    public Task<T> Add(T entity);
    public Task Update(T entity); 

    public Task Delete(T entity);

}
