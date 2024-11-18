using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HiLandon.Infrastructure;

/// <summary>Class used by EF Core tools to create the DbContext.</summary>
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
	/// <summary>Creates the DbContext.</summary>
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		// For local development: get the connection string from the user secrets of the backend project
		IConfigurationRoot configuration = new ConfigurationBuilder().AddUserSecrets("HiLandon").Build();
		string? connectionString = configuration.GetConnectionString("DefaultConnection");

		if (connectionString == null)
			throw new Exception("No connection string found.");

		DbContextOptionsBuilder<ApplicationDbContext> builder = new();
		// DbContextOptions<ApplicationDbContext> options = builder.UseSqlServer(connectionString, x => x.CommandTimeout(900)).Options;
		DbContextOptions<ApplicationDbContext> options = builder.UseInMemoryDatabase(connectionString).Options;
		return new(options);
	}
}