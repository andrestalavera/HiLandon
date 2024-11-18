using HiLandon.Core.Repositories;
using HiLandon.Infrastructure.Repositories;
using HiLandon.Presentation.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPostsRepository, PostsRepository>();

await builder.Build().RunAsync();
