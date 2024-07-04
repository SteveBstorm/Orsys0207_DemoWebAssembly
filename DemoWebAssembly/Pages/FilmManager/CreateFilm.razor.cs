using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace DemoWebAssembly.Pages.FilmManager
{
    public partial class CreateFilm
    {
        public Film NouveauFilm { get; set; }
        public List<string> listeGenre { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        [Parameter]
        public EventCallback NotifyRegister { get; set; }

        public string SelectedGenre { get; set; }

        protected override void OnInitialized()
        {
            NouveauFilm = new Film { Genre = "Action" };
            listeGenre = new List<string>();
            listeGenre.Add("Action");
            listeGenre.Add("Comédie");
            listeGenre.Add("Sci-fi");
            listeGenre.Add("Horreur");
        }

        public async Task ValidForm()
        {
            await Client.PostAsJsonAsync("api/film", NouveauFilm);
            await NotifyRegister.InvokeAsync();
        }
    }
}
