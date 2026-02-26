using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BabaPlayApp;
using App.Infrastructure.Extensions;
using App.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BabaPlayApp.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>() ?? new ApiSettings { BaseApiUri = "" });
builder.AddClientServices();

await builder.Build().RunAsync();
