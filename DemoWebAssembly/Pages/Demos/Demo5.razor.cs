using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo5
    {
        [Inject]
        public IJSRuntime js { get; set; }
    
        public IJSObjectReference jsRef { get; set; }

        public string MyValue { get; set; }
        public string ValueFromStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            jsRef = await js.InvokeAsync<IJSObjectReference>("import", "./script/myscript.js");
            await jsRef.InvokeVoidAsync("MyJSFunction");
        }

        public async Task SetValue()
        {
            //await js.InvokeVoidAsync("alert", MyValue);
            await js.InvokeVoidAsync("localStorage.setItem", "maclé", MyValue);
        }

        public async Task GetValue()
        {
            ValueFromStorage = await js.InvokeAsync<string>("localStorage.getItem", "maclé");
        }
    }
}
