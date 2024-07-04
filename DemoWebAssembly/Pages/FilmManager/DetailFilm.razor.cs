using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoWebAssembly.Pages.FilmManager
{
    public partial class DetailFilm
    {
        [Parameter]
        public int FilmId { get; set; }

        [Inject]
        public HttpClient Client { get; set; }
        public Film CurrentMovie { get; set; }

        protected override async Task OnParametersSetAsync()
        {

            CurrentMovie = await Client.GetFromJsonAsync<Film>("api/film/" + FilmId);
        }
    }
}
