using HiLandon.Core.Entities;
using HiLandon.Core.Repositories;

namespace HiLandon.Application.Posts;

public class GetPostsHandler(IPostsRepository repository) : IHandler<IReadOnlyList<Post>>
{
    public async Task<IReadOnlyList<Post>?> Handle(IReadOnlyList<Post> input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await repository.GetAll(cancellationToken);
    }
}
