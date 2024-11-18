using HiLandon.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HiLandon.Infrastructure.Repositories;

public class Repository<TEntity>(DbContextFactory<ApplicationDbContext> factory) : IRepository<TEntity>
    where TEntity : class, new()
{
    public async Task<TEntity> AddOrUpdate(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ApplicationDbContext? context = await factory.CreateDbContextAsync(cancellationToken) ?? throw new InvalidOperationException("Could not create DbContext");
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IReadOnlyList<TEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ApplicationDbContext? context = await factory.CreateDbContextAsync(cancellationToken) ?? throw new InvalidOperationException("Could not create DbContext");
        return await context.Set<TEntity>().ToListAsync(cancellationToken);
    }
}
