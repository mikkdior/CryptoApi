using CoinGecko.Entities.Response.Shared;
using System.Net.Mime;

namespace CryptoApi.Api;

/// <summary>
///     Структурная модель данных ApiCoin.
/// </summary>
public class CApiCoin : IApiCoin
{
    public string Id { get; set; }
    public string Donor { get; set; }
    public string FullName { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public decimal? UsdPrice { get; set; }
    public decimal? MarketCap { get; set; }
    public decimal? Low { get; set; }
    public decimal? High { get; set; }
}
