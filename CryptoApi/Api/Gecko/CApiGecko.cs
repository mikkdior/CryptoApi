using CoinGecko.Clients;
using CoinGecko.Entities.Response.Coins;
using CoinGecko.Interfaces;

namespace CryptoApi.Api.Gecko
{
    public class CApiGecko : CBaseApi, IApi
    {
        private readonly ICoinGeckoClient client;
        private IReadOnlyList<CoinFullData> CurrentCoins;

        public CApiGecko(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
            client = CoinGeckoClient.Instance;
        }
        IEnumerable<CoinMarkets> GetAllMarkets ()
        {
            int page = 1;

            while(true)
            {
                Console.WriteLine("before");
                var markets = client.CoinsClient.GetCoinMarkets("usd", new string[] { }, "market_cap_desc", 250, page++, false, "", "").Result;
                Console.WriteLine("after " + markets.Count + " " + (page - 1));

                if (markets.Count == 0) break;
                
                foreach (CoinMarkets market in markets)
                {
                    yield return market;
                }
            }
        }
        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            //CurrentCoins = await client.CoinsClient.GetAllCoinsData();
            //Console.WriteLine($"current coins: {CurrentCoins.Count()}");
            //var markets = await client.CoinsClient.GetCoinMarkets("usd");
            //Console.WriteLine($"markets: {markets.Count()}");
            //
            //return null;
            
            //var coins = await client.CoinsClient.GetCoinList();

            return new CGeckoCoinsData(GetAllMarkets(), null);
        }
        public async Task<IApiCoinPairsData> GetCoinPairsAsync()
        {
            return new CGeckoCoinPairsData(CurrentCoins);
        }

        public async Task TestAsync()
        {
            var markets = await client.CoinsClient.GetCoinMarkets("zoc");

            foreach(var market in markets)
            {
                Console.WriteLine($"{market.Name} - {market.PriceChange24H}");
            }
        }
    }
}
