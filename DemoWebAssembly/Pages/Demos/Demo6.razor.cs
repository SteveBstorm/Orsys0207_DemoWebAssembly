using DemoWebAssembly.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo6
    {
        /*
         L'objet qui sera lié au formulaire doit être instancier
         !!!NE PAS OUBLIER LES OBJETS COMPLEXES / IMBRIQUES !!!

        Microsoft.AspNetCore.Components.DataAnnotations.Validation
        Pour la validation des types complexes
         */
        public Film NouveauFilm { get; set; }
        public List<string> listeGenre { get; set; }

        protected override void OnInitialized()
        {
            NouveauFilm = new Film();
            listeGenre = new List<string>();
            listeGenre.Add("Action");
            listeGenre.Add("Comédie");
            listeGenre.Add("Sci-fi");
            listeGenre.Add("Horreur");
        }

        public void ValidForm()
        {
            Console.WriteLine(JsonSerializer.Serialize(NouveauFilm));
        }
    }
}
