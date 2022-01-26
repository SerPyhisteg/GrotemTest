using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace ToDoList.Network.Factories
{
    public class FlurlClientFactory : DefaultFlurlClientFactory
    {
        protected override IFlurlClient Create(Url url)
        {
            var client = base.Create(url);
            client.Settings.HttpClientFactory = new CommonHttpClientFactory();

            return client;
        }
    }
}
