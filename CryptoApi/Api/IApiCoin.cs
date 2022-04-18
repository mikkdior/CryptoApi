using CoinGecko.Entities.Response.Shared;

namespace CryptoApi.Api
{
    public interface IApiCoin
    {
        string Id { get; set; }
        string Donor { get; set; }
        string FullName { get; set; }
        string Name { get; set; }
        string? Image { get; set; }
        decimal? UsdPrice { get; set; }
        decimal? MarketCap { get; set; }
        decimal? Low { get; set; }
        decimal? High { get; set; }
        string CirculatingSupply { get; set; }
        decimal? TotalSupply { get; set; }
        long? MarketCapRank { get; set; }
        decimal? TotalVolume { get; set; }
    }
}
