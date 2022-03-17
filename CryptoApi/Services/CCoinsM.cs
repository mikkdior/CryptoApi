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
                slug = coin.Name 
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
                        Id = c.id,
                        FullName = c.name_full,
                        Name = c.name,
                        Title = c.name_full,
                        Url = $"/coins/{c.slug}"
                    }).Skip((page - 1)*count).Take(count);
        }

        public CCoinDataVM GetCoinByName (string name)
        {
            return (from c in db.Coins
                    where c.name == name
                    select new CCoinDataVM()
                    {
                        Id = c.id,
                        FullName = c.name_full,
                        Name = c.name,
                        Title = c.name_full,
                        Url = $"/coins/{c.slug}"
                    }).First<CCoinDataVM>();
        }

        public int GetMaxPage (int count)
        {
            int max_count = (int)Math.Ceiling(Count() / count * 1f);
            return max_count;
        }
    }
}
