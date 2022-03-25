namespace CryptoApi.Models.DB;

/// <summary>
///     Структурная модель данных CoinPairData из БД.
/// </summary>
public class CCoinPairDataM
{
    public uint id { get; set; }
    public uint coin1_id { get; set; }
    public uint coin2_id { get; set; }
    public string price_1 { get; set; }
    public string price_2 { get; set; }
    public string day_percent { get; set; }
    public string day_hight_1 { get; set; }
    public string day_hight_2 { get; set; }
    public string day_low_1 { get; set; }
    public string day_low_2 { get; set; }
    public string market_cap { get; set; }
    public ICollection<CCoinPairsMetaDataM> meta { get; set; }

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CCoinPairDataM ()
    {
        meta = new List<CCoinPairsMetaDataM> ();
    }

    /// <summary>
    ///     Возвращает все метаданные монеты, при условии совпадения group.
    /// </summary>
    public IEnumerable<CCoinPairsMetaDataM> this[string group]
    {
        get => meta.Where(x => x.group == group);
    }
    /// <summary>
    ///     Возвращает все метаданные монеты, при условии совпадения group & option.
    /// </summary>
    public CCoinPairsMetaDataM this[string group, string option]
    {
        get => meta.Where(x => x.group == group && x.option == option).FirstOrDefault();
    }
}
