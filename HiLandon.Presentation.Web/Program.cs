using HiLandon.Application.Posts;
using HiLandon.Core.Repositories;
using HiLandon.Infrastructure;
using HiLandon.Infrastructure.Repositories;
using HiLandon.Presentation.Web.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Configuration.AddUserSecrets("HiLandon");
string connectionString = builder.Configuration.GetConnectionString("DefaultDatabase") ?? throw new InvalidOperationException("Could not find connection string");
Console.WriteLine($"*** Connection string: {connectionString}");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddScoped<CreateOrUpdatePostHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
