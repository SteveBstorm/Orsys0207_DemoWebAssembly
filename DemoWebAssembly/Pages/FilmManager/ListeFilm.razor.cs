using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoWebAssembly.Pages.FilmManager
{
    public partial class ListeFilm
    {
        [Inject]
        public HttpClient Client { get; set; }

        public List<Film> Liste { get; set; }
        public int SelectedFilmId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Liste = new List<Film>();
            await LoadData();
        }

        private async Task LoadData()
        {
            Liste = await Client.GetFromJsonAsync<List<Film>>("api/film");
            
        }

        public void SelectFilm(int id)
        {
            SelectedFilmId = id;
        }


    }
}
