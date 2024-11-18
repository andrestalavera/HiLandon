using HiLandon.Core.Repositories;

namespace HiLandon.Application;

public abstract class CreateOrUpdateHandler<TEntity, TRepository>(TRepository repository) : IHandler<TEntity>
    where TEntity : new()
    where TRepository : IRepository<TEntity>
{
    public async Task<TEntity?> Handle(TEntity input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        TEntity? newOrUpdated = await repository.AddOrUpdate(input, cancellationToken);
        ArgumentNullException.ThrowIfNull(newOrUpdated);
        return newOrUpdated;
    }
}