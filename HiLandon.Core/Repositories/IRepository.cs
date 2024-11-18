namespace HiLandon.Core.Repositories;

public interface IRepository<T> where T : new()
{
    Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default);
    
    Task<T> AddOrUpdate(T entity, CancellationToken cancellationToken = default);
}
