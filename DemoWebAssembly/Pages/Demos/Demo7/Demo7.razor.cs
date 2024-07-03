using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Demos.Demo7
{
    public partial class Demo7
    {
        [Inject]
        public NavigationManager Nav { get; set; }
        public void Redirect()
        {
            Nav.NavigateTo("cible/17/x/coucou");
        }
    }
}
