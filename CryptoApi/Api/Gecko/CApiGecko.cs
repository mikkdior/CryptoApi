using CoinGecko.Clients;
using CoinGecko.Interfaces;

namespace CryptoApi.Api.Gecko
{
    public class CApiGecko : CBaseApi, IApi
    {
        private readonly ICoinGeckoClient _client;

        public CApiGecko(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
            _client = CoinGeckoClient.Instance;
        }
        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            var coins = await _client.CoinsClient.GetCoinList();

            return new CGeckoCoinsData(coins);
        }
    }
}
