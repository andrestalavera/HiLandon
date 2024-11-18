using HiLandon.Core.Entities;

namespace HiLandon.Core.Repositories;

#if V2||V3

public interface IUsersRepository : IRepository<User>;

#endif