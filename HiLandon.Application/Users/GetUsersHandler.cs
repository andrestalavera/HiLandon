
using HiLandon.Core.Entities;
using HiLandon.Core.Repositories;

namespace HiLandon.Application.Users;

public class GetUsersHandler(IUsersRepository repository) : IHandler<IReadOnlyList<User>>
{
    public async Task<IReadOnlyList<User>?> Handle(IReadOnlyList<User> input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await repository.GetAll(cancellationToken);
    }
}