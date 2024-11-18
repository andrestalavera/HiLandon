using HiLandon.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HiLandon.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Post>? Posts { get; set; }

#if V2
    public DbSet<User>? Users { get; set; }
#endif

#if V2||V3
    public DbSet<Tag>? Tags { get; set; }
#endif
}
