namespace CryptoApi.Api
{
    public interface IApiCoinPair
    {
        string Coin1 { get; set; }
        string Coin2 { get; set; }
        decimal Price1 { get; set; }
        decimal Price2 { get; set; }
        double DayPercent { get; set; }
        decimal DayHight1 { get; set; }
        decimal DayHight2 { get; set; }
        decimal DayLow1 { get; set; }
        decimal DayLow2 { get; set; }
        decimal MarketCap { get; set; }
    }
}
