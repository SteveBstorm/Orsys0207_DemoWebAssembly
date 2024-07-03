using DemoWebAssembly;
using DemoWebAssembly.Pages.Demos.Auth;
using Microsoft.AspNetCore.Components.Authorization;
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

//à ajouter pour l'authentification 
builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<AuthenticationStateProvider, MyStateProvider>();

await builder.Build().RunAsync();
