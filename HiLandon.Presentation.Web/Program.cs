using HiLandon.Application;
using HiLandon.Application.Posts;
using HiLandon.Core.Repositories;
using HiLandon.Infrastructure;
using HiLandon.Infrastructure.Repositories;
using HiLandon.Presentation.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Configuration.AddUserSecrets("HiLandon");
string connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");
Console.WriteLine($"*** Connection string: {connectionString}");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddScoped<CreateOrUpdatePostHandler>();

await builder.Build().RunAsync();
