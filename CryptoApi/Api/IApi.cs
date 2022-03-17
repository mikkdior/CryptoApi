namespace CryptoApi.Api
{
    public interface IApi
    {
        bool isLimit { get; }
        Task<IApiCoinsData> GetCoinsAsync();
    }
}
