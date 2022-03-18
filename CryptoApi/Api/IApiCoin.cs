using CoinGecko.Entities.Response.Shared;

namespace CryptoApi.Api
{
    public interface IApiCoin
    {
        string Id { get; set; }
        string Donor { get; set; }
        string FullName { get; set; }
        string Name { get; set; }
        string Image { get; set; }
        decimal Usd { get; set; }
        decimal MarketCap { get; set; }
        double ChangeDay { get; set; }
        double ChangeWeek { get; set; }
        double ChangeMonth { get; set; }
    }
}
