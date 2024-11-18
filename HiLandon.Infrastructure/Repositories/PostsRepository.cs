using HiLandon.Core.Entities;
using HiLandon.Core.Repositories;
using Microsoft.EntityFrameworkCore.Internal;

namespace HiLandon.Infrastructure.Repositories;

public class PostsRepository(DbContextFactory<ApplicationDbContext> factory) : Repository<Post>(factory), IPostsRepository
{
}