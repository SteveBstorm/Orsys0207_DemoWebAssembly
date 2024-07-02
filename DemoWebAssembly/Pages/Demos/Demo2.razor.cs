
using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo2
    {
        public int MyProperty { get; set; }

        [Inject]
        public HttpClient client { get; set; }
        protected override async Task OnInitializedAsync()
        {
            MyProperty = 17;
            await Console.Out.WriteLineAsync(MyProperty.ToString());
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                Console.WriteLine("coucou");
            }
            Console.WriteLine(MyProperty *=2);
        }

        protected override bool ShouldRender()
        {
            return MyProperty != 143;
        }

        

    }
}
