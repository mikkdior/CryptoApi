namespace CryptoApi.Api
{
    public interface IApiCoinsData
    {
        IEnumerable<IApiCoin> GetEnumerable();
    }
}
