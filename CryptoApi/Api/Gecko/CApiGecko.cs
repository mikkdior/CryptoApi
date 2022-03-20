using CoinGecko.Clients;
using CoinGecko.Entities.Response.Coins;
using CoinGecko.Interfaces;

namespace CryptoApi.Api.Gecko
{
    public class CApiGecko : CBaseApi, IApi
    {
        private readonly ICoinGeckoClient _client;
        private IReadOnlyList<CoinFullData> CurrentCoins;

        public CApiGecko(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
            _client = CoinGeckoClient.Instance;
        }
        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            CurrentCoins = await _client.CoinsClient.GetAllCoinsData();
            var coins = await _client.CoinsClient.GetCoinList();

            return new CGeckoCoinsData(CurrentCoins, coins);
        }
        public async Task<IApiCoinPairsData> GetCoinPairsAsync()
        {
            return new CGeckoCoinPairsData(CurrentCoins);
        }

        public async Task TestAsync()
        {
            var markets = await _client.CoinsClient.GetCoinMarkets("zoc");

            foreach(var market in markets)
            {
                Console.WriteLine($"{market.Name} - {market.PriceChange24H}");
            }
        }
    }
}
