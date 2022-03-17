using CryptoApi.Api.Paprika;

namespace CryptoApi.Api
{
    public class CApiPaprikaFactory : IApiFactory
    {
        IConfigurationSection data;
        public CApiPaprikaFactory(IConfigurationSection data)
        {
            this.data = data;
            Console.WriteLine(data["Url"]);
        }
        public IApi CreateApi(IConfigurationSection conf)
        {
            return new CApiPaprika(data, conf);
        }
    }
}
