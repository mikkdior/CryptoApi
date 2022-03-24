using CryptoApi.Api;
using CryptoApi.Models.DB;

namespace CryptoApi.Services
{
    public class CActualizerM
    {
        private CDbM db;
        private CCoinsM coinsModel;
        private CCoinPairsM coinPairsModel;
        private CApiManager api;
        private IConfiguration conf;

        public CActualizerM (CDbM db, CCoinsM coins, CCoinPairsM pair, CApiManager api)
        {
            this.db = db;
            this.coinsModel = coins;
            this.coinPairsModel = pair;
            this.api = api;

            conf = new ConfigurationBuilder().AddJsonFile("ConfApi.json").Build();
            var donors = conf.GetSection("Donors");
            api.Init(donors);
        }
        public async Task RefreshDataAsync ()
        {
            await RefreshCoinsAsync();
            await RefreshPairsAsync();
        }
        public async Task RefreshCoinsAsync()
        {
            var coins = api.GetCoinsAsync().Result;
            await coinsModel.AddCoinsAsync(coins);
        }
        public async Task RefreshPairsAsync()
        {
            var pairs = api.GetCoinPairsAsync().Result;
            await coinPairsModel.AddPairsAsync(pairs);
        }
        public async Task RunAsync ()
        {

        }

        public async Task RunNowAsync ()
        {
            await Task.Run(RefreshDataAsync);
        }

        public async Task LoadCoinsAsync()
        {
            await Task.Run(RefreshCoinsAsync);
        }

        public async Task LoadPairsAsync()
        {
            await Task.Run(RefreshPairsAsync);
        }

        public async Task TestAsync()
        {
            await Task.Run(api.TestAsync);
        }

        public async Task StopAsync ()
        {

        }

        public async Task ClearCoinsAsync()
        {
            db.Coins.RemoveRange(db.Coins);
            await db.SaveChangesAsync();
        }

        public async Task ClearPairsAsync()
        {
            db.CoinPairs.RemoveRange(db.CoinPairs);
            await db.SaveChangesAsync();
        }

        public async Task ClearAllAsync()
        {
            await ClearPairsAsync();
            await ClearCoinsAsync();
        }
    }
}
