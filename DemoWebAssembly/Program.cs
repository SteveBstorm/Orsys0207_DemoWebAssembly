using DemoWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7107/") });

//Ajouter Microsoft.Extensions.Http
builder.Services.AddHttpClient("clientAPI1", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://localhost:7107/");
});
builder.Services.AddHttpClient("clientAPI2", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://apis.goole.com/auth");
});
await builder.Build().RunAsync();
