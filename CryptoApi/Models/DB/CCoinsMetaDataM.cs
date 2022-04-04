using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApi.Models.DB;

/// <summary>
///     Структурная модель данных CoinsMetaData из БД.
/// </summary>
public class CCoinsMetaDataM
{
    public uint id { get; set; }
    public uint coins_id { get; set; }
    public string group { get; set; }
    public string option { get; set; }
    public string value { get; set; }
    




    [ForeignKey("coins_id")]
    public CCoinDataM coin { get; set; }
}
