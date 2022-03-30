namespace CryptoApi.Models.DB;

/// <summary>
///     Структурная модель данных CoinData из БД.
/// </summary>
public class CCoinDataM
{
    public uint id { get; set; }
    public string donor { get; set; }
    public string donor_id { get; set; }
    public string name_full { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
    public string? image { get; set; }
    public DateTime last_updated { get; set; }

    public ICollection<CCoinsMetaDataM> meta { get; set; }
    public ICollection<CCoinsExtDataM> ext { get; set; }

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CCoinDataM ()
    {
        meta = new List<CCoinsMetaDataM> ();
        ext = new List<CCoinsExtDataM> ();
    }

    /// <summary>
    ///     Возвращает все метаданные монеты, при условии совпадения group.
    /// </summary>
    public IEnumerable<CCoinsMetaDataM> this[string group]
    {
        get => meta.Where(x => x.group == group);
    }

    /// <summary>
    ///     Возвращает все метаданные монеты, при условии совпадения group & option.
    /// </summary>
    public CCoinsMetaDataM this[string group, string option]
    {
        get => meta.Where(x => x.group == group && x.option == option).FirstOrDefault();
    }
}
