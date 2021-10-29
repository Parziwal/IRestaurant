using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRestaurant.Test.WebAPIIntegrationTests
{
    public class MockBackChannel : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.AbsoluteUri.Equals("https://localhost:5000/.well-known/openid-configuration"))
            {
                return Task.FromResult(GetOpenIdConfigurationAsResponseMessage("openid-configuration.json"));
            }
            if (request.RequestUri.AbsoluteUri.Equals("https://localhost:5000/.well-known/openid-configuration/jwks"))
            {
                return Task.FromResult(GetOpenIdConfigurationAsResponseMessage("openid-jwks.json"));
            }
            throw new NotImplementedException();
        }

        private HttpResponseMessage GetOpenIdConfigurationAsResponseMessage(string resource)
        {
            string path = $"WebAPIIntegrationTests/well-known/{resource}";
            using (var s = new StreamReader(path))
            {
                var body = s.ReadToEnd();
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                return new HttpResponseMessage()
                {
                    Content = content,
                };
            }
        }
    }
}
