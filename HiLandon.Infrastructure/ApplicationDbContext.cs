using HiLandon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HiLandon.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext
{
    public DbSet<Post>? Posts { get; set; }

#if V2
    public DbSet<User>? Users { get; set; }
#endif

#if V2||V3
    public DbSet<Tag>? Tags { get; set; }
#endif
}


/// <summary>Class used by EF Core tools to create the DbContext.</summary>
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
	/// <summary>Creates the DbContext.</summary>
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		// For local development: get the connection string from the user secrets of the backend project
		IConfigurationRoot configuration = new ConfigurationBuilder().Build();
		string? connectionString = configuration.GetConnectionString("DefaultConnection");

		if (connectionString == null)
			throw new Exception("No connection string found.");

		DbContextOptionsBuilder<ApplicationDbContext> builder = new();
		DbContextOptions<ApplicationDbContext> options = builder.UseSqlServer(connectionString, x => x.CommandTimeout(900)).Options;
		return new(options);
	}
}