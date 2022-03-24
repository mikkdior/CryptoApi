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
        public async Task AddPairAsync(IApiCoinPair pair, bool save = true)
        {
            var new_pair = ApiToData(pair);
            if (new_pair == null) return;

            var result = db.CoinPairs.AddAsync(new_pair);

            if (save) await db.SaveChangesAsync();
        }
        public async Task UpdatePairAsync(IApiCoinPair pair, CCoinPairDataM old_pair, bool save = true)
        {
            ApiToData(pair, old_pair);
            if (save) await db.SaveChangesAsync();
        }
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
            /*return (from p in db.CoinPairs
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
                    .FirstOrDefault<CCoinPairDataVM>();*/
        }

        public int GetMaxPage(int count)
        {
            int max_count = (int)Math.Ceiling(Count() / count * 1f);
            return max_count;
        }
    }
}
