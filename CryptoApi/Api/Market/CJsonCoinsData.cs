namespace CryptoApi.Api.Market;

public class CJsonCoinsData
{
    public CStatusData? status { get; set; }
    public List<CJsonCoinData>? data { get; set; }
}
public class CStatusData
{
    public DateTime timestamp { get; set; }
    public int error_code { get; set; }
    public string? error_message { get; set; }
    public int elapsed { get; set; }
    public int credit_count { get; set; }
    public string? notice { get; set; }
}