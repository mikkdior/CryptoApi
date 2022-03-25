namespace CryptoApi.Api.Market;

public class CJsonCoinData
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? symbol { get; set; }
    public string? slug { get; set; }
    public int cmc_rank { get; set; }
    public int num_market_pairs { get; set; }
    public int circulating_supply { get; set; }
    public int max_supply { get; set; }
    public DateTime last_updated { get; set; }
    public DateTime date_added { get; set; }
    public List<string>? tags { get; set; }
    public string? platform { get; set; }
    public Dictionary<string, CQuoteData>? quote { get; set; }
}
public class CQuoteData
{
    public decimal price { get; set; }
    public int volume_24h { get; set; }
    public decimal volume_change_24h { get; set; }
    public decimal percent_change_1h { get; set; }
    public decimal percent_change_24h { get; set; }
    public decimal percent_change_7d { get; set; }
    public decimal market_cap { get; set; }
    public long market_cap_dominance { get; set; }
    public decimal fully_diluted_market_cap { get; set; }
    public DateTime last_updated { get; set; }
}
