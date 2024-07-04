using Microsoft.JSInterop;

namespace DemoWebAssembly.MiddleWare
{
    public class TokenInterceptor : DelegatingHandler
    {
        private readonly IJSRuntime JS;

        public TokenInterceptor(IJSRuntime jS)
        {
            JS = jS;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            if(!string.IsNullOrEmpty(token) )
            {
                request.Headers.Add("Authorization", "bearer " + token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
