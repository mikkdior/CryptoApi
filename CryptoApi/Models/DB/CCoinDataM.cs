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

    public decimal? day_change => CCurrMath.GetChangePrice(1, ext);
    public decimal? day_percent_change => CCurrMath.GetChangePercentPrice(1, ext);
    public decimal? week_percent_change => CCurrMath.GetChangePercentPrice(7, ext);
    public decimal? month_percent_change => CCurrMath.GetChangePercentPrice(30, ext);

    public decimal? usd_price => ext.Last()?.usd_price == 0 ? 0 : ext.Last()?.usd_price;
    public decimal? market_cap => ext.Last()?.market_cap;
    public decimal? low => ext.Last()?.low;
    public decimal? high => ext.Last()?.high;

    public decimal? circulating_supply => 10633197;
    public decimal? max_supply => 18900000;
    public decimal? cmc_rank => 72;
    public decimal? volume_24h => 828881044;
    public decimal? change_1h => 2.21m;

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
