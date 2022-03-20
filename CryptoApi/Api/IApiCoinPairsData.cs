namespace CryptoApi.Api
{
    public interface IApiCoinPairsData
    {
        IEnumerator<IApiCoinPair> GetEnumerator();
    }
}
