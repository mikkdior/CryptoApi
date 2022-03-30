using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApi.Models.DB;

/// <summary>
///     Структурная модель данных CoinPairsMetaData из БД.
/// </summary>
public class CCoinPairsMetaDataM
{
    public uint id { get; set; }
    public uint coin_1_id { get; set; }
    public uint coin_2_id { get; set; }
    public string? group { get; set; }
    public string option { get; set; }
    public string value { get; set; }
}
