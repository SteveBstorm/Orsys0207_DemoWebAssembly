using Microsoft.AspNetCore.SignalR.Client;

namespace DemoWebAssembly.Pages.Demos.SignalRChat
{
    public partial class Chat
    {
        //Microsoft.AspNetCore.SignalR.Client

        public HubConnection Connexion{ get; set; }
        public List<string> Messages { get; set; }

        public string NewMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Messages = new List<string>();
            Connexion = new HubConnectionBuilder().WithUrl("https://localhost:7107/chathub").Build();
            await Connexion.StartAsync();

            Connexion.On("SendMessage", (string message) =>
            {
                Messages.Add(message);
                StateHasChanged();
            });
        }

        public async Task EnvoiMessage()
        {
            await Connexion.SendAsync("SendMessage", NewMessage);
        }

        public async Task JoinGroup()
        {
            await Connexion.SendAsync("JoinGroup", "monsupergroupe");
            Connexion.On("SendToGroup_monsupergroupe", (string message) =>
            {
                Messages.Add(message);
                StateHasChanged();
            });
        }

        public async Task SendToGroup()
        {
            await Connexion.SendAsync("SendToGroup", "monsupergroupe", NewMessage);
        }
    }
}
