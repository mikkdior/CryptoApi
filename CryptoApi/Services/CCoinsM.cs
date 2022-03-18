using CryptoApi.Api;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;

namespace CryptoApi.Services
{
    public class CCoinsM : CBaseDbM
    {
        public CCoinsM(CDbM db) : base(db)
        {
        }
        public bool HasCoin(string donor, string name)
        {
            var has_coin = from c in db.Coins
                           where c.donor == donor && c.name == name
                           select c;

            return has_coin.Count<CCoinDataM>() > 0;
        }
        public bool HasCoin (CCoinDataM coin)
        {
            return HasCoin(coin.donor, coin.name);
        }
        public bool HasCoin(IApiCoin coin)
        {
            return HasCoin(coin.Donor, coin.Name);
        }
        public async Task AddCoinAsync(IApiCoin coin, bool save = true)
        {
            if (HasCoin(coin)) return;
            await db.Coins.AddAsync(new CCoinDataM()
            {
                donor = coin.Donor,
                donor_id = coin.Id,
                name_full = coin.FullName,
                name = coin.Name,
                slug = coin.Name,
                usd = coin.Usd,
                image = coin.Image,
                market_cap = coin.MarketCap.ToString(),
                change_day = coin.ChangeDay.ToString(),
                change_week = coin.ChangeWeek.ToString(),
                change_month = coin.ChangeMonth.ToString(),
                change_price = coin.ChangePrice.ToString()
            });

            if (save) await db.SaveChangesAsync();
        }

        public async Task AddCoinsAsync(IApiCoinsData coins)
        {
            foreach (var coin in coins) await AddCoinAsync(coin, false);
            await db.SaveChangesAsync();
        }

        public int Count()
        {
            return db.Coins.Count<CCoinDataM>();
        }

        public IEnumerable<CCoinDataVM> GetCoins (int page, int count)
        {
            return  (from c in db.Coins
                    select new CCoinDataVM()
                    {
                        data = c
                    }).Skip((page - 1)*count).Take(count);
        }

        public CCoinDataVM GetCoinByName (string name)
        {
            return (from c in db.Coins
                    where c.name == name
                    select new CCoinDataVM()
                    {
                        data = c
                    }).FirstOrDefault<CCoinDataVM>();
        }

        public int GetMaxPage (int count)
        {
            int max_count = (int)Math.Ceiling(Count() / count * 1f);
            return max_count;
        }
    }
}
