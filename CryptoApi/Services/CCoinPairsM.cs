using CryptoApi.Api;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CryptoApi.Services;

/// <summary>
///     Модель (сервис), для работы с CoinPairs из БД.
/// </summary>
public class CCoinPairsM : CBaseDbM
{
    CCoinsM coinsModel;

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели. Передает модель БД родителю.
    /// </summary>
    public CCoinPairsM(CDbM db, CCoinsM coins) : base(db)
    {
        coinsModel = coins;
    }

    /// <summary>
    ///     Проверяет, есть ли пара в БД, используя id двух монет.
    /// </summary>
    public bool HasPair (uint id1, uint id2)
    {
        return db.CoinPairs.Where(p => p.coin1_id == id1 && p.coin2_id == id2).Select(p => p).Count() > 0;
    }

    /// <summary>
    ///     Проверяет, есть ли пара в БД, используя name двух монет.
    /// </summary>
    public CCoinPairDataM? HasPair(string name1, string name2)
    {
        return db.CoinPairs
            .Join
            (
                db.Coins,
                pair => pair.coin1_id,
                coin => coin.id,
                (pair, coin) => new { Pair = pair, Coin = coin }
            )
            .Join
            (
                db.Coins,
                data => data.Pair.coin2_id,
                coin => coin.id,
                (data, coin) => new { Pair = data.Pair, Coin1 = data.Coin, Coin2 = coin }
            )
            .Where(data => data.Coin1.name == name1 && data.Coin2.name == name2)
            .Select(data => data.Pair)
            .FirstOrDefault();
    }

    /// <summary>
    ///     Асинхронно добавляет пару.
    /// </summary>
    public async Task AddPairAsync(IApiCoinPair pair, bool save = true)
    {
        var new_pair = ApiToData(pair);
        if (new_pair == null) return;

        var result = db.CoinPairs.AddAsync(new_pair); //?

        if (save) await db.SaveChangesAsync();
    }

    /// <summary>
    ///     Асинхронно обновляет пару.
    /// </summary>
    public async Task UpdatePairAsync(IApiCoinPair pair, CCoinPairDataM old_pair, bool save = true)
    {
        ApiToData(pair, old_pair);
        if (save) await db.SaveChangesAsync();
    }

    /// <summary>
    ///     Асинхронно вытягивает пару.
    /// </summary>
    public CCoinPairDataM ApiToData (IApiCoinPair pair, CCoinPairDataM? data = null)
    {
        var new_pair = data;
        
        if (new_pair == null)
        {
            var coins = coinsModel.GetCoinsByNames(new string[] { pair.Coin1, pair.Coin2 });
            if (coins.Count() != 2) return null;

            new_pair = new CCoinPairDataM();
            new_pair.coin1_id = coins[pair.Coin1].id;
            new_pair.coin2_id = coins[pair.Coin2].id;
        }
        
        new_pair.price_1 = pair.Price1.ToString();
        new_pair.price_2 = pair.Price2.ToString();
        new_pair.day_percent = pair.DayPercent.ToString();
        new_pair.day_hight_1 = pair.DayHight1.ToString();
        new_pair.day_hight_2 = pair.DayHight2.ToString();
        new_pair.day_low_1 = pair.DayLow1.ToString();
        new_pair.day_low_2 = pair.DayLow2.ToString();
        new_pair.market_cap = pair.MarketCap.ToString();

        return new_pair;
    }

    /// <summary>
    ///     Асинхронно добавляет пары.
    /// </summary>
    public async Task AddPairsAsync(IEnumerable<IApiCoinPair> pairs)
    {
        foreach (var pair in pairs) 
        {
            var old_pair = HasPair(pair.Coin1, pair.Coin2);
            
            if (old_pair != null)
                UpdatePairAsync(pair, old_pair, false);
            else
                AddPairAsync(pair, false); 
        }

        await db.SaveChangesAsync();
    }

    /// <summary>
    ///     Возвращает количество пар.
    /// </summary>
    public int Count()
    {
        return db.CoinPairs.Count();
    }

    /// <summary>
    ///     Достает пары из БД используя исходное заданное количество и номер страницы.
    /// </summary>
    public IEnumerable<CCoinPairDataVM> GetPairs(int page, int count)
    {
        return (from p in db.CoinPairs
                
                join c1 in db.Coins on p.coin1_id equals c1.id
                join c2 in db.Coins on p.coin2_id equals c2.id
                
                select new CCoinPairDataVM()
                {
                    data = p,
                    coin1 = c1,
                    coin2 = c2
                })
                //.Include(p => p.meta)
                .Skip((page - 1) * count)
                .Take(count);
    }

    /// <summary>
    ///     Достает пару из БД используя name монет.
    /// </summary>
    public CCoinPairDataVM GetPairByNames(string name1, string name2)
    {
        return db.CoinPairs
            .Include(p => p.meta)
            .Join
            (
                db.Coins,
                pair => pair.coin1_id,
                coin => coin.id,
                (pair, coin) => new { Pair = pair, Coin = coin }
            )
            .Join
            (
                db.Coins,
                data => data.Pair.coin2_id,
                coin => coin.id,
                (data, coin) => new { Pair = data.Pair, Coin1 = data.Coin, Coin2 = coin }
            )
            .Where(data => data.Coin1.name == name1 && data.Coin2.name == name2)
            .Select(data => new CCoinPairDataVM()
            {
                data = data.Pair,
                coin1 = data.Coin1,
                coin2 = data.Coin2
            })
            .FirstOrDefault();
    }

    /// <summary>
    ///     Достает похожие пары из БД используя id исходной пары.
    /// </summary>
    public IEnumerable<CCoinPairDataM> GetSimiliarPairs(CCoinPairDataM pair)
    {
        return from item in pair["pairs"]
               where item.coinpairsid == pair.id
               select db.CoinPairs.Find(uint.Parse(item.value));
    }

    /// <summary>
    ///     Возвращает число максимально возможной страницы для пагинации.
    /// </summary>
    public int GetMaxPage(int count)
    {
        int max_count = (int)Math.Ceiling(Count() / count * 1f);
        return max_count;
    }
}
