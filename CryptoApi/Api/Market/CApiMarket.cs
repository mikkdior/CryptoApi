namespace CryptoApi.Api.Market
{
    public class CApiMarket : CBaseApi, IApi
    {
        public CApiMarket(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
        }
        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            Console.WriteLine("CApiMarket");
            return default;
        }
    }
}
