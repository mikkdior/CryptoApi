namespace CryptoApi.Api
{
    public interface IApiFactory
    {
        IApi CreateApi(IConfigurationSection conf);
    }
}
