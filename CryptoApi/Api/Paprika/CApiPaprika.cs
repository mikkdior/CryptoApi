namespace CryptoApi.Api.Paprika
{
    public class CApiPaprika : CBaseApi, IApi
    {
        public CApiPaprika(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
        }

        public Task<IApiCoinPairsData> GetCoinPairsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            Console.WriteLine("CApiPaprika");
            return default;
        }

        public Task TestAsync()
        {
            throw new NotImplementedException();
        }
    }
}
