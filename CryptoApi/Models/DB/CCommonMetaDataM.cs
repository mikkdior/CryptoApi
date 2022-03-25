namespace CryptoApi.Models.DB;

/// <summary>
///     Структурная модель данных CommonMetaData из БД.
/// </summary>
public class CCommonMetaDataM
{
    public uint id { get; set; }
    public string group { get; set; }
    public string option { get; set; }
    public string value { get; set; } 
}
