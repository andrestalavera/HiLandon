using HiLandon.Core.Repositories;

namespace HiLandon.Application;

public abstract class GetItemsHandler<TEntity, TRepository>(TRepository repo)
    : IHandler<IEnumerable<TEntity>>
    where TRepository : IRepository<TEntity>
    where TEntity : new()
{
    public async Task<IEnumerable<TEntity>?> Handle(IEnumerable<TEntity> input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await repo.GetAll(cancellationToken);
    }
}
