using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Child : ComponentBase
    {
        [Parameter]
        public int ValueFromParent { get; set; }

        [Parameter]
        public string Question { get; set; }

        [Parameter]
        public EventCallback<string> Reponse { get; set; }


        public void Repondre(string r)
        {
            Reponse.InvokeAsync(r);
        }

        public int CurrentValue { get; set; }
        protected override void OnParametersSet()
        {
            CurrentValue = ValueFromParent + 2;
        }
    }
}
