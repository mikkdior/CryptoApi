using System.ComponentModel.DataAnnotations;

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
    private string? _image { get; set; }
    public string? image
    {
        get
        {
            return _image != null ? _image : "/images/coin-unknown.png";
        }
        set
        {
            _image = value;
        }
    }
    public DateTime last_updated { get; set; }
    public bool? enable { get; set; }

    public decimal? day_change => ext.Count() == 0 ? null : CCurrMath.GetChangePrice(1, ext);

    public decimal? day_percent_change => ext.Count() == 0 ? null : CCurrMath.GetChangePercentPrice(1, ext);
    public decimal? week_percent_change => ext.Count() == 0 ? null : CCurrMath.GetChangePercentPrice(7, ext);
    public decimal? month_percent_change => ext.Count() == 0 ? null : CCurrMath.GetChangePercentPrice(30, ext);

    public decimal? usd_price => ext.Count() == 0 ? null : ext.Last()?.usd_price;

    public decimal? market_cap => ext.Count() == 0 ? null : ext.Last()?.market_cap;
    public decimal? low => ext.Count() == 0 ? null : ext.Last()?.low;
    public decimal? high => ext.Count() == 0 ? null : ext.Last()?.high;

    public string circulating_supply => ext.Count() == 0 ? "" : ext.Last().circulating_supply;

    public string max_supply => ext.Count() == 0 ? null : ext.Last().total_supply;
    public decimal? cmc_rank => ext.Count() == 0 ? null : ext.Last().market_cap_rank;
    public decimal? volume_24h => ext.Count() == 0 ? null : ext.Last().total_volume;
    public decimal? change_1h => ext.Count() == 0 ? null : 2.21m;

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
