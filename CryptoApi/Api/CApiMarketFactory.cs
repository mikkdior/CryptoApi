using CryptoApi.Api.Market;

namespace CryptoApi.Api
{
    public class CApiMarketFactory : IApiFactory
    {
        IConfigurationSection data;
        public CApiMarketFactory(IConfigurationSection data)
        {
            this.data = data;
        }
        public IApi CreateApi(IConfigurationSection conf)
        {
            return new CApiMarket(data, conf);
        }
    }
}
