namespace CryptoApi.Api.Market
{
    public class CApiMarket : CBaseApi, IApi
    {
        public CApiMarket(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
        }

        public Task<IApiCoinPairsData> GetCoinPairsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            Console.WriteLine("CApiMarket");
            return default;
        }

        public Task TestAsync()
        {
            throw new NotImplementedException();
        }
    }
}
