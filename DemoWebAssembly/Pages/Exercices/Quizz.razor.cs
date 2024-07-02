using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Exercices
{
    public partial class Quizz
    {
        [Parameter]
        public string Prenom { get; set; }

        [Parameter]
        public EventCallback<string> RepondreEvent { get; set; }

        public List<string> Questions { get; set; }
        public int Compteur { get; set; }

        protected override void OnInitialized()
        {
            Questions = new List<string>();
            Questions.Add("La sieste a t'elle été agréable ?");
            Questions.Add("Blazor vous plait il ?");
            Questions.Add("On continue ?");

            Compteur = 0;
        }

        public void Repondre(string reponse)
        {
            RepondreEvent.InvokeAsync(reponse);
            Compteur++;
        }
    }
}
