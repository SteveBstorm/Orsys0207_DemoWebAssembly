using DemoWebAssembly;
using DemoWebAssembly.MiddleWare;
using DemoWebAssembly.Pages.Demos.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7107/") });
builder.Services.AddTransient<TokenInterceptor>();



//Ajouter Microsoft.Extensions.Http
builder.Services.AddHttpClient("clientAPI1", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://localhost:7107/");
}).AddHttpMessageHandler<TokenInterceptor>();

builder.Services.AddScoped<HttpClient>(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("clientAPI1"));

builder.Services.AddHttpClient("clientAPI2", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://apis.goole.com/auth");
});



//à ajouter pour l'authentification 
//builder.Services.AddAuthorizationCore(o => o.AddPolicy("claimid1", options => { options.RequireClaim("UserId").Equals(1); }));
builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<AuthenticationStateProvider, MyStateProvider>();
//System.Globalization
//Microsoft.AspNetCore.Localization v2.1.1
//Microsoft.Extensions.Localization

builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(o =>
{
    List<CultureInfo> cultureInfos = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("fr-FR")
    };

    o.SetDefaultCulture("fr-FR");
    o.SupportedCultures = cultureInfos;
    o.SupportedUICultures = cultureInfos;
});


//await builder.Build().RunAsync();

WebAssemblyHost host = builder.Build();

CultureInfo cultureInfo;
IJSRuntime js = host.Services.GetRequiredService<IJSRuntime>();

string currentCulture = await js.InvokeAsync<string>("localStorage.getItem", "blazorCulture");

if (currentCulture is not null)
{
    cultureInfo = new CultureInfo(currentCulture);
}else
{
    cultureInfo= new CultureInfo("fr-FR");
    await js.InvokeVoidAsync("localStorage.setItem", "blazorCulture", cultureInfo.Name);
}

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

await host.RunAsync();
