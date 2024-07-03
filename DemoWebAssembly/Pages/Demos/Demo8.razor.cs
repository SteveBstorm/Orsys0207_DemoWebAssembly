using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo8
    {
        [Inject]
        public IHttpClientFactory Factory { get; set; }


        [Inject]
        public HttpClient Client { get; set; }
        public List<Film> Liste { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Liste = new List<Film>();
            HttpClient c = Factory.CreateClient("clientAPI1");

            Liste = await c.GetFromJsonAsync<List<Film>>("api/film");
        
            
        }
    }
}
