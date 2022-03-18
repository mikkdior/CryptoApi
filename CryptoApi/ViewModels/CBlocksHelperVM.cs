using CryptoApi.Models.DB;
using CryptoApi.Services;

namespace CryptoApi.ViewModels
{
    public class CBlocksHelperVM
    {
        CDbM db;
        WebApplication app;
        IConfiguration conf;
        CCoinsM coinsModel;

        public CBlocksHelperVM (IConfiguration conf, CDbM db, CCoinsM coins_model)
        {
            this.db = db;
            this.coinsModel = coins_model;
            this.conf = conf;
        }

        public IEnumerable<CCoinDataVM> GetCoinList(int count, int page = 1)
        {
            return coinsModel.GetCoins(page, count);
        }
    }
}
