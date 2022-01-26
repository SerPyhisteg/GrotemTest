using Flurl.Http.Configuration;
using ModernHttpClient;
using System.Net;
using System.Net.Http;

namespace ToDoList.Network.Factories
{
    public class CommonHttpClientFactory : DefaultHttpClientFactory
    {
        public CommonHttpClientFactory()
        {
        }

        public override HttpMessageHandler CreateMessageHandler()
        {

#if DEBUG
            var handler = new NativeMessageHandler(false, new TLSConfig() { DangerousAcceptAnyServerCertificateValidator = true }, proxy: WebRequest.GetSystemWebProxy())
#else
                var handler = new NativeMessageHandler(false, new TLSConfig())
#endif
            {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                UseCookies = false,
            };

            return handler;
        }

        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            var client = base.CreateHttpClient(handler);
            client.DefaultRequestHeaders.Add("Accept", "application/json, */*");
            return client;
        }
    }
}
