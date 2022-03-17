using CryptoApi.Api;
using CryptoApi.Models.DB;

namespace CryptoApi.Services
{
    public class CCoinsM : CBaseDbM
    {
        public CCoinsM(CDbM db) : base(db)
        {
        }

        public async Task AddCoinAsync(IApiCoin coin, bool save = true)
        {
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
    }
}
