namespace CryptoApi.Api;

/// <summary>
///     Структурная модель данных ApiCoinPair.
/// </summary>
public class CApiCoinPair : IApiCoinPair
{
    public string Coin1 { get; set; }
    public string Coin2 { get; set; }
    public decimal Price1 { get; set; }
    public decimal Price2 { get; set; }
    public double DayPercent { get; set; }
    public decimal DayHight1 { get; set; }
    public decimal DayHight2 { get; set; }
    public decimal DayLow1 { get; set; }
    public decimal DayLow2 { get; set; }
    public decimal MarketCap { get; set; }
}
