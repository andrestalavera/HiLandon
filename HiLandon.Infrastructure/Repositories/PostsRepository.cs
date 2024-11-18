using HiLandon.Core.Entities;
using HiLandon.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HiLandon.Infrastructure.Repositories;

public class PostsRepository(IDbContextFactory<ApplicationDbContext> factory) 
    : Repository<Post>(factory), 
    IPostsRepository;