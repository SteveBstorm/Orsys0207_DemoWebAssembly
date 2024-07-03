using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace DemoWebAssembly.Pages.Demos.Auth
{
    public partial class Login
    {
        public LoginForm Form { get; set; }

        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        protected override void OnInitialized()
        {
            Form = new LoginForm();
        }

        public async Task SubmitLogin()
        {
            HttpResponseMessage message = await Client.PostAsJsonAsync("api/auth", Form);
            if (!message.IsSuccessStatusCode)
            {
                await Console.Out.WriteLineAsync("Problème : " + message.ReasonPhrase);
            }
            string token = await message.Content.ReadAsStringAsync();
            await JS.InvokeVoidAsync("localStorage.setItem", "token", token);
            ((MyStateProvider)StateProvider).NotifyUserChanged();
        }
    }
}
