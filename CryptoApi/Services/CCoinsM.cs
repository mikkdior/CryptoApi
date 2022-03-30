using CryptoApi.Api;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CryptoApi.Services;

/// <summary>
///     Модель (сервис), для работы с CoinPairs из БД.
/// </summary>
public class CCoinsM : CBaseDbM
{
    /// <summary>
    ///     Конструктор. Передает модель БД родителю.
    /// </summary>
    public CCoinsM(CDbM db) : base(db) { }

    /// <summary>
    ///     Возвращает словарь с моделями монет по ключу name монеты.
    /// </summary>
    public Dictionary<string, CCoinDataM> GetCoinsByNames(string[] names)
    {
        var coins = db.Coins.Where(c => names.Contains(c.name)).Select(c => c).ToList();
        var coins_dict = new Dictionary<string, CCoinDataM>();
        
        foreach (var coin in coins)
        {
            coins_dict.TryAdd(coin.name, coin);
        }

        return coins_dict;
    }

    /// <summary>
    ///     Проверяет, есть ли пара в БД, используя donor & id монеты.
    /// </summary>
    public CCoinDataM? HasCoin(string donor, string name)
    {
        return db.Coins.Where(c => c.name == name).FirstOrDefault();
    }

    /// <summary>
    ///     Проверяет, есть ли пара в БД, используя id монеты.
    /// </summary>
    public CCoinDataM? HasCoin (CCoinDataM coin)
    {
        return HasCoin(coin.donor, coin.name);
    }

    /// <summary>
    ///     Проверяет, есть ли пара в БД, используя name монеты.
    /// </summary>
    public CCoinDataM? HasCoin(IApiCoin coin)
    {
        return HasCoin(coin.Donor, coin.Name);
    }

    /// <summary>
    ///     Асинхронно добавляет монету.
    /// </summary>
    public async Task AddCoinAsync(IApiCoin coin, bool save = true)
    {
        await db.Coins.AddAsync(ApiToData(coin));
        if (save) await db.SaveChangesAsync();
    }

    /// <summary>
    ///     Асинхронно обновляет монету.
    /// </summary>
    public async Task UpdateCoinAsync(IApiCoin coin, CCoinDataM? has_coin, bool save = true)
    {
        ApiToData(coin, has_coin);
        if (save) await db.SaveChangesAsync();
    }

    /// <summary>
    ///     Асинхронно вытягивает монету.
    /// </summary>
    public CCoinDataM ApiToData (IApiCoin coin, CCoinDataM? data = null)
    {
        var new_coin = data ?? new CCoinDataM();
        var now = DateTime.Now;

        new_coin.donor = coin.Donor;
        new_coin.donor_id = coin.Id;
        new_coin.name_full = coin.FullName;
        new_coin.name = coin.Name;
        new_coin.slug = coin.Name;
        new_coin.image = coin.Image;
        new_coin.last_updated = now;

        if (coin.UsdPrice == null) return new_coin;

        var ext = new CCoinsExtDataM()
        {
            usd_price = coin.UsdPrice,
            market_cap = coin.MarketCap,
            low = coin.Low,
            high = coin.High,
            last_updated = now,
        };

        new_coin.ext.Add(ext);

        return new_coin;
    }

    /// <summary>
    ///     Асинхронно добавляет монеты.
    /// </summary>
    public async Task AddCoinsAsync(IEnumerable<IApiCoin> coins)
    {
        if (coins == null) return;

        foreach (var coin in coins)
        {
            var has_coin = HasCoin(coin);

            if (has_coin != null) 
                await UpdateCoinAsync(coin, has_coin, false);
            else
                await AddCoinAsync(coin, false);
        }

        await db.SaveChangesAsync();
    }

    /// <summary>
    ///     Возвращает количество монет.
    /// </summary>
    public int Count()
    {
        return db.Coins.Count<CCoinDataM>();
    }

    /// <summary>
    ///     Достает монеты из БД используя исходное заданное количество и номер страницы.
    /// </summary>
    public IEnumerable<CCoinDataVM> GetCoins (int page, int count)
    {
        return db.Coins
            .Include(c => c.ext)
            .Select(c => new CCoinDataVM()
            {
                data = c
            })
            .Skip((page - 1) * count)
            .Take(count);
    }

    /// <summary>
    ///     Достает похожие монеты из БД используя id исходной пары.
    /// </summary>
    public IEnumerable<CCoinDataVM> GetCoins(CCoinDataM coin)
    {
        return from item in coin["coins"]
               where item.coins_id == coin.id
               select new CCoinDataVM() { data = db.Coins.Find(uint.Parse(item.value)) };
    }

    /// <summary>
    ///     Достает монету из БД используя name монеты.
    /// </summary>
    public CCoinDataVM GetCoinByName (string name)
    {
        return db.Coins
            .Where(c => c.name == name)
            .Include(c => c.meta)
            .Include(c => c.ext)
            .Select(c => new CCoinDataVM()
            {
                data = c
            })
            .FirstOrDefault();
    }

    /// <summary>
    ///     Возвращает число максимально возможной страницы для пагинации.
    /// </summary>
    public int GetMaxPage (int count)
    {
        int max_count = (int)Math.Ceiling(Count() / count * 1f);
        return max_count;
    }

    public void Clear ()
    {
        db.Coins.RemoveRange(db.Coins);
    }
}
