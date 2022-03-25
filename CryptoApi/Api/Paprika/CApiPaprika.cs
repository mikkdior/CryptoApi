using CoinpaprikaAPI;
using CoinpaprikaAPI.Entity;

namespace CryptoApi.Api.Paprika
{
    public class CApiPaprika : CBaseApi, IApi
    {
        Client client;
        public CApiPaprika(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
            client = new Client();
        }

        public async Task<IApiCoinPairsData> GetCoinPairsAsync()
        {
            var coins = (await client.GetCoinsAsync()).Value;

            return new CPaprikaCoinPairsData(coins, id =>
            {
                var data = new Dictionary<string, OhlcValue>();
                var curs = new string[] { "USD", "btc" };
                
                foreach (var cur in curs)
                {
                    var res = client.GetLatestOhlcForCoinAsync(id, cur).Result;
                    //var res = client.GetTodayOhlcForCoinAsync(id, cur).Result;
                    if (res != null) continue;

                    data.Add(cur, res.Value[0]);

                }
                Console.WriteLine(data.Count());
                return data;
            });
        }

        public Dictionary<string, ExtendedExchangeInfo> InfoListToDict (List<ExtendedExchangeInfo> coins)
        {
            var dict = new Dictionary<string, ExtendedExchangeInfo>();

            foreach (var coin in coins)
            {
                dict.Add(coin.Id, coin);
            }

            return dict;
        }

        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            var coins = await client.GetCoinsAsync();
            Inc();
            var info = await client.GetExchangesAsync();
            Inc();
            var info_dict = InfoListToDict(info.Value);

            /*foreach (var data in info.Value)
            {
                Console.WriteLine(data.Id);
                foreach (var pair in data.Quotes)
                {
                    Console.WriteLine(pair.Key + " " + pair.Value.AdjustedVolume30D);
                }
                Console.WriteLine("---------------");

            }
            Console.WriteLine("count: " + info_dict.Count);
            return null;*/

            return new CPaprikaCoinsData(coins.Value, info_dict);
        }

        public Task TestAsync()
        {
            throw new NotImplementedException();
        }
    }
}
