namespace CryptoApi.Models.DB;

/// <summary>
///     Структурная модель данных CoinPairData из БД.
/// </summary>
public class CCoinPairDataM
{
    public uint coin1_id => coin_1.id;
    public uint coin2_id => coin_2.id;
    public string name_1 => coin_1.name.ToUpper();
    public string name_2 => coin_2.name.ToUpper();
    public string name_full_1 => coin_1.name_full;
    public string name_full_2 => coin_2.name_full;

    public decimal? price_1 => CCurrMath.Exchange(coin_1.ext.LastOrDefault()?.usd_price, coin_2.ext.LastOrDefault()?.usd_price);
    public decimal? price_2 => CCurrMath.Exchange(coin_2.ext.LastOrDefault()?.usd_price, coin_1.ext.LastOrDefault()?.usd_price);

    public decimal? day_change_1 => coin_1.day_change;
    public decimal? day_percent_change_1 => coin_1.day_percent_change;
    public decimal? week_percent_change_1 => coin_1.week_percent_change;
    public decimal? month_percent_change_1 => coin_1.month_percent_change;

    public decimal? day_change_2 => coin_2.day_change;
    public decimal? day_percent_change_2 => coin_2.day_percent_change;
    public decimal? week_percent_change_2 => coin_2.week_percent_change;
    public decimal? month_percent_change_2 => coin_2.month_percent_change;

    public decimal? day_percent => 0;// { get; set; }
    public decimal? day_high_1 => coin_1.high;// { get; set; }
    public decimal? day_high_2 => coin_2.high;// { get; set; }
    public decimal? day_low_1 => coin_1.low;// { get; set; }
    public decimal? day_low_2 => coin_2.low;// { get; set; }
    public decimal? market_cap => coin_1.market_cap;// { get; set; }

    public string max_supply_1 => coin_1.max_supply;
    public string max_supply_2 => coin_2.max_supply;

    public decimal? cmc_rank_1 => coin_1.cmc_rank;
    public decimal? cmc_rank_2 => coin_2.cmc_rank;

    public decimal? volume_24h_1 => coin_1.volume_24h;
    public decimal? volume_24h_2 => coin_2.volume_24h;

    public string? circulating_supply_1 => coin_1.circulating_supply;
    public string? circulating_supply_2 => coin_2.circulating_supply;

    public IEnumerable<CCoinPairsMetaDataM> meta { get; private set; }
    public CCoinDataM coin_1 { get; private set; }
    public CCoinDataM coin_2 { get; private set; }

    public CCoinPairDataM(CCoinDataM coin1, CCoinDataM coin2, IEnumerable<CCoinPairsMetaDataM> meta)
    {
        coin_1 = coin1;
        coin_2 = coin2;
        this.meta = meta;
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
