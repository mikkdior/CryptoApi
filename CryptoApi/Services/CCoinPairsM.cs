using CryptoApi.Api;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CryptoApi.Services
{
    public class CCoinPairsM : CBaseDbM
    {
        CCoinsM coinsModel;
        public CCoinPairsM(CDbM db, CCoinsM coins) : base(db)
        {
            coinsModel = coins;
        }
        public bool HasPair (uint id1, uint id2)
        {
            return db.CoinPairs.Where(p => p.coin1_id == id1 && p.coin2_id == id2).Select(p => p).Count() > 0;
        }
        public async Task AddPairAsync(IApiCoinPair pair, bool save = true)
        {
            var coins = coinsModel.GetCoinsByNames(new string[] { pair.Coin1, pair.Coin2 });
            if (coins.Count() != 2) return;
            if (HasPair(coins[pair.Coin1].id, coins[pair.Coin2].id)) return;

            var result = db.CoinPairs.AddAsync(new CCoinPairDataM()
            {
                coin1_id = coins[pair.Coin1].id,
                coin2_id = coins[pair.Coin2].id,
                price_1 = pair.Price1.ToString(),
                price_2 = pair.Price2.ToString(),
                day_percent = pair.DayPercent.ToString(),
                day_hight_1 = pair.DayHight1.ToString(),
                day_hight_2 = pair.DayHight2.ToString(),
                day_low_1 = pair.DayLow1.ToString(),
                day_low_2 = pair.DayLow2.ToString(),
                market_cap = pair.MarketCap.ToString()
            }).Result;

            if (save) await db.SaveChangesAsync();
        }

        public async Task AddPairsAsync(IApiCoinPairsData pairs)
        {
            foreach (var pair in pairs) { AddPairAsync(pair, false); }
            await db.SaveChangesAsync();
        }

        public int Count()
        {
            return db.CoinPairs.Count();
        }

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

        public CCoinPairDataVM GetPairByNames(string name1, string name2)
        {
            return (from p in db.CoinPairs
                    join c1 in db.Coins on p.coin1_id equals c1.id
                    join c2 in db.Coins on p.coin2_id equals c2.id
                    where c1.name == name1
                    where c2.name == name2
                    select new CCoinPairDataVM()
                    {
                        data = p,
                        coin1 = c1,
                        coin2 = c2
                    })
                    .Include(p => p.meta)
                    .FirstOrDefault<CCoinPairDataVM>();
        }

        public int GetMaxPage(int count)
        {
            int max_count = (int)Math.Ceiling(Count() / count * 1f);
            return max_count;
        }
    }
}
