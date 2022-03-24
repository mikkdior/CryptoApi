namespace CryptoApi.Api
{
    public interface IApiCoinPairsData
    {
        IEnumerable<IApiCoinPair> GetEnumerable();
    }
}
