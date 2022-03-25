using CoinpaprikaAPI;

namespace CryptoApi.Api.Paprika
{
    public class CApiPaprika : CBaseApi, IApi
    {
        Client client;
        public CApiPaprika(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
            client = new Client();
        }

        public Task<IApiCoinPairsData> GetCoinPairsAsync()
        {

            return default;
        }

        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            var coins = await client.GetCoinsAsync();
            client.
            foreach (var coin in coins.Value)
                Console.WriteLine(coin.Name);

            return default;
        }

        public Task TestAsync()
        {
            throw new NotImplementedException();
        }
    }
}
