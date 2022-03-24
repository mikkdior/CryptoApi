using CryptoApi.Api;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CryptoApi.Services
{
    public class CCoinsM : CBaseDbM
    {
        public CCoinsM(CDbM db) : base(db)
        {
        }
        public CCoinDataM? HasCoin(string donor, string name)
        {
            return db.Coins.SingleOrDefault(coin => coin.donor == donor && coin.name == name);
        }
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
        public CCoinDataM? HasCoin (CCoinDataM coin)
        {
            return HasCoin(coin.donor, coin.name);
        }
        public CCoinDataM? HasCoin(IApiCoin coin)
        {
            return HasCoin(coin.Donor, coin.Name);
        }
        public async Task AddCoinAsync(IApiCoin coin, bool save = true)
        {
            await db.Coins.AddAsync(ApiToData(coin));
            if (save) await db.SaveChangesAsync();
        }
        public async Task UpdateCoinAsync(IApiCoin coin, CCoinDataM? has_coin, bool save = true)
        {
            ApiToData(coin, has_coin);
            if (save) await db.SaveChangesAsync();
        }
        public CCoinDataM ApiToData (IApiCoin coin, CCoinDataM? data = null)
        {
            var new_coin = data ?? new CCoinDataM();

            new_coin.donor = coin.Donor;
            new_coin.donor_id = coin.Id;
            new_coin.name_full = coin.FullName;
            new_coin.name = coin.Name;
            new_coin.slug = coin.Name;
            new_coin.usd = coin.Usd;
            new_coin.image = coin.Image;
            new_coin.market_cap = coin.MarketCap.ToString();
            new_coin.change_day = coin.ChangeDay.ToString();
            new_coin.change_week = coin.ChangeWeek.ToString();
            new_coin.change_month = coin.ChangeMonth.ToString();
            new_coin.change_price = coin.ChangePrice.ToString();

            return new_coin;
        }
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

        public int Count()
        {
            return db.Coins.Count<CCoinDataM>();
        }

        public IEnumerable<CCoinDataVM> GetCoins (int page, int count)
        {
            return db.Coins
                //.Include(c => c.meta)
                .Select(c => new CCoinDataVM()
                {
                    data = c
                })
                .Skip((page - 1) * count)
                .Take(count);
        }

        public CCoinDataVM GetCoinByName (string name)
        {
            return db.Coins
                .Where(c => c.name == name)
                .Include(c => c.meta)
                .Select(c => new CCoinDataVM()
                {
                    data = c
                })
                .FirstOrDefault();
        }

        public int GetMaxPage (int count)
        {
            int max_count = (int)Math.Ceiling(Count() / count * 1f);
            return max_count;
        }
    }
}
