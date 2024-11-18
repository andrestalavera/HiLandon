namespace HiLandon.Application.Posts;

public class CreateOrUpdatePostHandler(IPostsRepository repository)
        : CreateOrUpdateHandler<Post, IPostsRepository>(repository);
