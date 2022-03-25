namespace CryptoApi.Models.DB;

/// <summary>
///     Структурная модель данных CoinPairsMetaData из БД.
/// </summary>
public class CCoinPairsMetaDataM
{
    public uint id { get; set; }
    public uint coinpairsid { get; set; }
    public string group { get; set; }
    public string option { get; set; }
    public string value { get; set; }
    public CCoinPairDataM pair { get; set; }
}
