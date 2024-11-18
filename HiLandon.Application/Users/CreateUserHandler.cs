namespace HiLandon.Application.Users;

public class CreateOrUpdateUserHandler(IUsersRepository repository) : IHandler<User>
{
    public async Task<User?> Handle(User input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        User user = await repository.AddOrUpdate(input, cancellationToken);
        ArgumentNullException.ThrowIfNull(user);
        return user;
    }
}
