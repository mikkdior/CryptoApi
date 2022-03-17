using CryptoApi.Api.Gecko;

namespace CryptoApi.Api
{
    public class CApiGeckoFactory : IApiFactory
    {
        IConfigurationSection data;
        public CApiGeckoFactory(IConfigurationSection data)
        {
            this.data = data;
        }
        public IApi CreateApi(IConfigurationSection conf)
        {
            return new CApiGecko(data, conf);
        }
    }
}
