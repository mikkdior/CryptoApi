namespace CryptoApi.Api
{
    public interface IApiCoinsData
    {
        IEnumerator<IApiCoin> GetEnumerator();
    }
}
