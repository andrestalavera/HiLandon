namespace HiLandon.Application;

public interface IHandler<TEntity>
{
    Task<TEntity?> Handle(TEntity input, CancellationToken cancellationToken = default);
}