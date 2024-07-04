using System.ComponentModel.DataAnnotations;


namespace DemoWebAssembly.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = nameof(Resources.App._salut), 
            ErrorMessageResourceType = typeof(Resources.App))]

        //passer le fichier resx en public
        public string Titre { get; set; }
        [Range(1977, 2024)]
        public int AnneeSortie { get; set; }
        [MinLength(10)]
        public string Synopsis { get; set; }
        //Microsoft.AspNetCore.Components.DataAnnotations.Validation
        [ValidateComplexType]
        public Personne Realisateur { get; set; }

        [Required]
        public string Genre { get; set; }

        public bool Bonfilm { get; set; }

        public Film()
        {
            Realisateur = new Personne();
        }
    }

    public class Personne
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
    }
}
